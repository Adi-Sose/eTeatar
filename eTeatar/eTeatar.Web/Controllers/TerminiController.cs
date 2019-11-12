using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using eTeatar.Web.Paypal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eTeatar.Web.ViewModels.Termini;
using Microsoft.EntityFrameworkCore;

namespace eTeatar.Web.Controllers
{
    public class TerminiController : Controller
    {

        private readonly MojContext _context;

        public TerminiController(MojContext context)
        {
            _context = context;
        }

        [Route("Termini")]
        public IActionResult Index()
        {
            bool IsLoggedIn = !string.IsNullOrEmpty(HttpContext.User.Identity.Name);
            int GradKupca = 0;

            if (IsLoggedIn)
                GradKupca = _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name).GradId;

            IndexVM Model = new IndexVM
            {
                IsLoggedIn = !IsLoggedIn,

                Termini = _context.Termin
                //.Where(w=>w.DatumVrijeme > DateTime.Now)
                .Where(w => w.Dvorana.Teatar.GradId == (!IsLoggedIn || GradKupca==1 ? w.Dvorana.Teatar.GradId : GradKupca)).Select(s => new IndexVM.Termin{
                    Datum = s.DatumVrijeme.ToString("dd.MM.yyyy - HH:mm"),
                    Grad = s.Dvorana.Teatar.Grad.Naziv,
                    Teatar = s.Dvorana.Teatar.Naziv,
                    Predstava = s.Predstava.Naziv,
                    PredstavaId = s.PredstavaId,
                    TerminId = s.Id
                }).ToList() 
            };

            return View(Model);
        }

        [Authorize(Roles = "Kupac")]
        [Route("/Termini/Checkout/{id}")]
        public IActionResult Checkout(int id)
        {
            CheckoutVM Model = _context.Termin.Where(w => w.Id == id).Select(s => new CheckoutVM
            {
                TerminId = s.Id,
                CijenaKarte = s.BaznaCijenaKarte,
                BrojKarata = 1,
                Datum = s.DatumVrijeme.ToString("dd.MM.yyyy - HH:mm"),
                Predstava = s.Predstava.Naziv,
                Grad = s.Dvorana.Teatar.Grad.Naziv,
                Teatar = s.Dvorana.Teatar.Naziv,
                Dvorana = s.Dvorana.Naziv,
                TipoviSjedista = s.Dvorana.DvoranaTipSjedista.Select(q => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = q.TipSjedista.Naziv + " (" + ((q.TipSjedista.CijenaKarteMultiplier * s.BaznaCijenaKarte) 
                                                          - (q.TipSjedista.CijenaKarteMultiplier * s.BaznaCijenaKarte
                                                          * _context.Kupac.Where(w=>w.Username==HttpContext.User.Identity.Name).Select(r=>r.TipKorisnika.CijenaKartePopust).First())
                                                         ).ToString(CultureInfo.InvariantCulture) + "KM)",
                    Value = q.TipSjedistaId.ToString()
                }).ToList()
            }).First();
            return View(Model);
        }

        [Authorize(Roles = "Kupac")]
        [Route("Ajax/Termini/Checkout")]
        public IActionResult CheckoutAjax(float cijenaKarte, int tipSjedistaId, int brojKarata, int terminId)
        {
            if (brojKarata <= 0)
                return Content("");

            float cijenaKarteMultiplier = _context.TipSjedista.Find(tipSjedistaId).CijenaKarteMultiplier;
            float cijenKartePopust = _context.Kupac.Where(w => w.Username == HttpContext.User.Identity.Name).Select(s => s.TipKorisnika.CijenaKartePopust).First();

            CheckoutAjaxVM Model = new CheckoutAjaxVM
            {
                PreostaloKarata = (_context.DvoranaTipSjedista.First(w=> w.TipSjedistaId == tipSjedistaId && w.DvoranaId == _context.Termin.First(q=>q.Id == terminId).DvoranaId).BrojSjedista
                -_context.Narudzba.Where(w=>w.TerminId == terminId && w.TipSjedistaId == tipSjedistaId).Sum(a=>(int?)a.Kolicina)??0).ToString() ,
                UkupnaCijena = (brojKarata * (cijenaKarteMultiplier * cijenaKarte - (cijenaKarte * cijenaKarteMultiplier * cijenKartePopust))).ToString(CultureInfo.InvariantCulture)
            };

            return PartialView(Model);
        }

        [Authorize(Roles = "Kupac")]
        [Route("Termini/Checkout/Payment")]
        public async Task<IActionResult> PaymentAsync(CheckoutVM model)
        {

            if (model.BrojKarata > (_context.DvoranaTipSjedista.First(w => w.TipSjedistaId == model.TipSjedistaId && w.DvoranaId == _context.Termin.First(q => q.Id == model.TerminId).DvoranaId).BrojSjedista
                - _context.Narudzba.Where(w => w.TerminId == model.TerminId && w.TipSjedistaId == model.TipSjedistaId).Sum(a => (int?)a.Kolicina) ?? 0))
                return Redirect("~/Termini/Checkout/" + model.TerminId.ToString());

            Data.Models.Termin termin = _context.Termin.Include("Predstava").First(w => w.Id == model.TerminId);
            Data.Models.TipSjedista tipSjedista = _context.TipSjedista.First(w => w.Id == model.TipSjedistaId);

            string Naziv = termin.Predstava.Naziv + " " + termin.DatumVrijeme.ToString("dd.MM.yyyy HH:mm") + " " + tipSjedista.Naziv;
            double Cijena = (termin.BaznaCijenaKarte * tipSjedista.CijenaKarteMultiplier) - (termin.BaznaCijenaKarte * tipSjedista.CijenaKarteMultiplier * _context.Kupac.Where(w => w.Username == HttpContext.User.Identity.Name).Select(s => s.TipKorisnika.CijenaKartePopust).First());

            TempData["TerminId"] = model.TerminId;
            TempData["BrojKarata"] = model.BrojKarata;
            TempData["TipSjedistaId"] = model.TipSjedistaId;
            TempData["CijenaKarte"] = Cijena;

            string SucessUrl = "http://" + Request.Host.ToString() + "/Termini/Checkout/PaymentSuccess";
            string CancelUrl = "http://" + Request.Host.ToString();

            string link = await PayPalHelper.GeneratePayment(Naziv, (float)Cijena / 2, model.BrojKarata, SucessUrl, CancelUrl);
            return Redirect(link);
        }

        [Authorize(Roles = "Kupac")]
        [Route("Termini/Checkout/PaymentSuccess")]
        public async Task<IActionResult> PaymentSuccessAsync(string paymentId, string payerId)
        {

            int TerminId = (int)TempData["TerminId"];
            int BrojKarata = (int)TempData["BrojKarata"];
            int TipSjedistaId = (int)TempData["TipSjedistaId"];
            double Cijena = (double)TempData["CijenaKarte"];

            TempData.Remove("TerminId");
            TempData.Remove("BrojKarata");
            TempData.Remove("TipSjedistaId");
            TempData.Remove("CijenaKarte");
            if (await PayPalHelper.ExecutePayment(paymentId, payerId))
            {
                _context.Narudzba.Add(new Data.Models.Narudzba
                {
                    TerminId = TerminId,
                    TipSjedistaId = TipSjedistaId,
                    CijenaKarte = (float)Cijena,
                    Kolicina = BrojKarata,
                    KupacId = _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name).Id,
                });

                _context.SaveChanges();
                return Redirect("~/MojProfil");
            }

            else
            {
                return Content("Doslo je do greske!");
            }

        }

        [Route("CreateProfile")]
        public async Task<IActionResult> Create()
        {
            return Content(await PayPalHelper.CreateProfile());
        }

    }
}