using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.Paypal;
using eTeatar.Web.ViewModels.Kupac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Narudzba = eTeatar.Web.ViewModels.Kupac.Narudzba;

namespace eTeatar.Web.Controllers
{
    [Authorize(Roles = "Kupac")]
    public class KupacController : Controller
    {
        private readonly MojContext _context;

        public KupacController(MojContext context)
        {
            _context = context;
        }

        [Route("MojProfil")]
        public IActionResult Index()
        {
            IndexVM Model = _context.Kupac.Where(w => w.Username == HttpContext.User.Identity.Name).Select(s =>
                new IndexVM
                {
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Email = s.Korisnik.Email,
                    UserName = s.Username,
                    Avatar = s.Avatar.Link,
                    AvatarId = s.AvatarId,
                    TipKorisnika = s.TipKorisnika.Naziv,
                    IduciTipKorisnika = s.TipKorisnika.IduciTipKorisnika.Naziv,
                    IduciTipKorisnikaId = s.TipKorisnika.IduciTipKorisnikaId,
                    Narudzbe = s.Narudzbe.Select(q => new Narudzba
                    {
                        Id = q.Id,
                        Predstava = q.Termin.Predstava.Naziv,
                        Datum = q.Termin.DatumVrijeme.ToString("dd.MM.yyyy"),
                        Vrijeme = q.Termin.DatumVrijeme.ToString("HH:mm"),
                        BrKarata = q.Kolicina.ToString(),
                        Dvorana = q.Termin.Dvorana.Naziv,
                        Teatar = q.Termin.Dvorana.Teatar.Naziv,
                        Cijena = (q.CijenaKarte * q.Kolicina).ToString("0.00") + " KM",
                        Sjediste = q.TipSjedista.Naziv,
                        Ocjena = q.Ocjena == null ? (int?) null : q.Ocjena.Vrijednost
                    }).OrderByDescending(o => o.Datum).ToList()
                }).First();

            return View(Model);
        }

        [Route("Ajax/Kupac/Avatari/{TrenutniAvatar}")]
        public IActionResult IndexAjax(int trenutniAvatar)
        {
            IndexAjaxVM Model = new IndexAjaxVM
            {
                Avatari = _context.Avatar.Select(s => new IndexAjaxVM.Avatar
                {
                    Id = s.Id,
                    Link = s.Link,
                    Selected = s.Id == trenutniAvatar
                }).ToList()
            };

            return PartialView(Model);
        }

        public IActionResult UpdateAvatar(int avatarId)
        {
            _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name).AvatarId = avatarId;
            _context.SaveChanges();
            return Redirect("~/MojProfil");
        }


        [Route("Ajax/Kupac/Email")]
        public IActionResult IndexAjaxEmail()
        {
            IndexAjaxEmailVM Model = new IndexAjaxEmailVM
            {
                Email = _context.Korisnik.First(w => w.UserName == HttpContext.User.Identity.Name).Email
            };

            return View(Model);
        }

        public IActionResult UpdateEmail(IndexAjaxEmailVM model)
        {
            _context.Korisnik.First(w => w.UserName == HttpContext.User.Identity.Name).Email = model.Email;
            _context.SaveChanges();
            return Redirect("~/MojProfil");
        }

        public IActionResult DodajOcjenu(int narudzbaId, int ocjena)
        {
            Ocjena OcjenaNova = new Ocjena
            {
                NarudzbaId = narudzbaId,
                Vrijednost = ocjena
            };
            _context.Ocjena.Add(OcjenaNova);
            _context.Narudzba.First(w => w.Id == narudzbaId).Ocjena = OcjenaNova;
            _context.SaveChanges();

            return Redirect("~/MojProfil");
        }


        [Route("MojProfil/Upgrade")]
        public async Task<IActionResult> UpgradeCheckout()
        {
            TipKorisnika IduciTipKorisnika = _context.Kupac.Where(w => w.Username == HttpContext.User.Identity.Name)
                .Select(s => s.TipKorisnika.IduciTipKorisnika).First();

            string Naziv = IduciTipKorisnika.Naziv;
            double Cijena = IduciTipKorisnika.Cijena;

            string SucessUrl = "http://" + Request.Host + "/MojProfil/UpgradeSuccess";
            string CancelUrl = "http://" + Request.Host + "/MojProfil";

            return Redirect(await PayPalHelper.GeneratePayment(Naziv, (float) Cijena, 1, SucessUrl, CancelUrl));
        }

        [Route("MojProfil/UpgradeSuccess")]
        public async Task<IActionResult> UpgradeSuccess(string paymentId, string payerId)
        {
            if (!await PayPalHelper.ExecutePayment(paymentId, payerId)) return Content("Doslo je do greske!");

            Kupac Kupac = _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name);
            TipKorisnika IduciTipKorisnika = _context.TipKorisnika.Where(w => w.Id == Kupac.TipKorisnikaId)
                .Select(s => s.IduciTipKorisnika).First();

            Kupac.TipKorisnika = IduciTipKorisnika;
            _context.SaveChanges();

            return Redirect("~/MojProfil");
        }
    }
}