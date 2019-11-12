using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTeatar.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Protected Members

        /// <summary>
        /// Pristup bazi podataka
        /// </summary>
        private readonly MojContext _context;

        /// <summary>
        /// Dodavanje, briasnje, pretraga uloga... Korisnika
        /// </summary>
        private readonly UserManager<Korisnik> _userManager;

        /// <summary>
        /// Dodavanje i brisanje Uloga
        /// </summary>
         private readonly RoleManager<IdentityRole> _roleManager;
        
        #endregion

        public HomeController(MojContext context, UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Route("~/")]
        public IActionResult Index()
        {

            IndexVM Model = new IndexVM
            {
                IsLoggedIn = string.IsNullOrEmpty(HttpContext.User.Identity.Name),
                Username = HttpContext.User.Identity.Name,

                //Svi termini grupisani po predstavama, poredani po vremenu igranja predstave, izdvojeni potrebni podaci i uzeta prva 3
                Predstave = _context.Termin
                                     .GroupBy(g => g.Predstava)
                                     .OrderBy(o => o.First().DatumVrijeme).ThenBy(o => o.First().DatumVrijeme.TimeOfDay)
                                     .Select(s => new ViewModels.Home.IndexVM.Predstava
                                     {
                                         Id = s.Key.Id,
                                         Naslov = s.Key.Naziv,
                                         Zanrovi = string.Join(", ", _context.PredstavaZanr.Where(w => w.PredstavaId == s.Key.Id).Select(q => q.Zanr.Naziv).ToList()),
                                         SlikaLink = s.Key.SlikaLink
                                     }).Take(3).ToList(),

                //Zadnja obavijest u sistemu
                GlavnaNovost = _context.Obavijest
                                       .OrderBy(o => o.DatumVrijeme.Date).ThenBy(o => o.DatumVrijeme.TimeOfDay)
                                       .Select(s => new ViewModels.Home.IndexVM.Novost
                                       {
                                           Id = s.Id, Naslov = s.Naslov, GlavnaNovostOpis = s.Sadrzaj
                                       }).FirstOrDefault(),

                //2,3,4 i 5 obavijest unazad u sistemu
                SporedneNovosti = _context.Obavijest
                                       .OrderBy(o => o.DatumVrijeme.Date).ThenBy(o => o.DatumVrijeme.TimeOfDay)
                                       .Select(s => new ViewModels.Home.IndexVM.Novost
                                       {
                                           Id = s.Id,
                                           Naslov = s.Naslov,
                                           SlikaLink = s.SlikaLink
                                       }).Skip(1).ToList()
            };
            
            DateTime PrviPonedjeljak = DateTime.MinValue, Danas = DateTime.Now;
            DateTime PrviUMjesecu = new DateTime(Danas.Year, Danas.Month, 1);

            for (int i = 0; i > -7; i--)
            {
                DateTime Datum = PrviUMjesecu.AddDays(i);
                if (Datum.DayOfWeek == DayOfWeek.Monday)
                    PrviPonedjeljak = Datum;
            }

            Model.KalendarCelije = new List<ViewModels.Home.IndexVM.KalendarCelija>();
            ////42 dana od prvog ponedjeljka na kalendaru
            for (int i = 0; i<42;i++)
            {
                Model.KalendarCelije.Add(new ViewModels.Home.IndexVM.KalendarCelija { Datum = PrviPonedjeljak.AddDays(i).Day.ToString(), BrojPredstava = _context.Termin.Count(w => w.DatumVrijeme.Date == PrviPonedjeljak.AddDays(i).Date).ToString()});
            }

            return View(Model);
        }

        [Route("/InitializeDB")]
        public async Task<IActionResult> InitializeAsync()
        {
            await DBInitializer.IzvrsiAsync(_context, _userManager,_roleManager);
            return Content("Ok");
        }

    }
}
