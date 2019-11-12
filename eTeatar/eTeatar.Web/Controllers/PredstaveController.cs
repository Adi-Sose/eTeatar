using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using eTeatar.Data;
using eTeatar.Web.ViewModels.Predstave;
using Microsoft.AspNetCore.Mvc;

namespace eTeatar.Web.Controllers
{
    public class PredstaveController : Controller
    {
        /// <summary>
        ///     Pristup bazi podataka
        /// </summary>
        private readonly MojContext _context;

        public PredstaveController(MojContext context)
        {
            _context = context;
        }

        [Route("/Predstave")]
        public IActionResult Index()
        {
            IndexVM Model = new IndexVM
            {
                IsLoggedIn = string.IsNullOrEmpty(HttpContext.User.Identity.Name),
                Username = HttpContext.User.Identity.Name,
                Zanrovi = _context.Zanr.Select(s => new Zanr
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Oznacen = false
                }).ToList()
            };

            //return new JsonResult(Model);

            return View(Model);
        }

        [Route("/Ajax/Predstave/Index")]
        public IActionResult IndexAjax(IndexVM modelIn)
        {
            List<int> Zanrovi = _context.Zanr.Select(s => s.Id).ToList();

            if (modelIn.Zanrovi != null)
            {
                List<int> OznaceniZanrovi = modelIn.Zanrovi.Where(w => w.Oznacen).Select(s => s.Id).ToList();
                if (OznaceniZanrovi.Count != 0)
                    Zanrovi = modelIn.Zanrovi.Where(w => w.Oznacen).Select(s => s.Id).ToList();
            }

            IndexAjaxVM Model = new IndexAjaxVM
            {
                Predstave = _context.Termin
                    /*.Where(w => w.DatumVrijeme > DateTime.Now)*/
                    .Where(w => w.Predstava.Naziv.Contains(modelIn.Search ?? "")
                                && w.Predstava.PredstavaZanr.Select(q => q.ZanrId).Intersect(Zanrovi).Any())
                    .GroupBy(g => g.Predstava)
                    .Select(s => new IndexAjaxVM.Predstava
                    {
                        Id = s.Key.Id,
                        Naziv = s.Key.Naziv,
                        Opis = s.Key.Opis.Substring(0, Math.Min(s.Key.Opis.Length, 440)) + "...",
                        SlikaLink = s.Key.SlikaLink,
                        Ocjena = _context.Ocjena.Where(w => w.Narudzba.Termin.PredstavaId == s.Key.Id)
                                     .Average(a => (double?) a.Vrijednost) ?? 0,
                        OcjenaLink =
                            Math.Round(
                                _context.Ocjena.Where(w => w.Narudzba.Termin.PredstavaId == s.Key.Id)
                                    .Average(a => (int?) a.Vrijednost) ?? 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture) +
                            "star.svg",
                        Zanrovi = string.Join(", ",
                            _context.PredstavaZanr.Where(w => w.PredstavaId == s.Key.Id).Select(q => q.Zanr.Naziv)
                                .ToList()),
                        GlavnaUloga = string.Join(", ",
                            _context.Uloga.Where(w => w.PredstavaId == s.Key.Id && w.IsGlavnaUloga)
                                .Select(q => q.Glumac.Ime + " " + q.Glumac.Prezime).ToList())
                    }).Where(w => Math.Round(w.Ocjena == 0 ? 1 : w.Ocjena) >= modelIn.Rating).ToList()
            };

            return PartialView(Model);
        }


        [Route("/Predstave/Detalji/{id}")]
        public IActionResult Detalji(int id)
        {
            DetaljiVM Model = _context.Predstava.Where(w => w.Id == id).Select(s => new DetaljiVM
            {
                SlikaLink = s.SlikaLink,
                Naziv = s.Naziv,
                IzvornoDjelo = s.NazivIzvornogDjela,
                Opis = s.Opis,
                Reziser = s.ReziserImePrezime,
                Zanrovi = string.Join(", ", s.PredstavaZanr.Select(q => q.Zanr.Naziv).ToList()),
                Ocjena = "LargeStar" +
                         Math.Round(
                                 (_context.Ocjena.Where(w => w.Narudzba.Termin.PredstavaId == id)
                                      .Average(a => (int?) a.Vrijednost) ?? 5) * 2, MidpointRounding.AwayFromZero)
                             .ToString(CultureInfo.InvariantCulture) + ".svg",
                Termini = _context.Termin.Where(w => w.PredstavaId == id).Select(q => new DetaljiVM.Termin
                {
                    Datum = q.DatumVrijeme.ToString("dd.MM.yyyy - HH:mm"),
                    Grad = q.Dvorana.Teatar.Grad.Naziv,
                    Teatar = q.Dvorana.Teatar.Naziv,
                    TerminId = q.Id
                }).ToList(),
                Uloge = s.Uloge.Select(q => new DetaljiVM.Uloga
                {
                    Glumac = q.Glumac.Ime + " " + q.Glumac.Prezime,
                    UlogaNaziv = q.Naziv
                }).ToList(),
                IsLoggedIn = string.IsNullOrEmpty(HttpContext.User.Identity.Name),
                GlavniGlumac = s.Uloge.Where(w => w.IsGlavnaUloga).Select(q => q.Glumac.Ime + " " + q.Glumac.Prezime)
                    .First()
            }).First();

            return View(Model);
        }
    }
}