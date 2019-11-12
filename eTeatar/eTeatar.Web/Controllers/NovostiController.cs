using System;
using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.ViewModels.Novosti;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Komentar = eTeatar.Web.ViewModels.Novosti.Komentar;

namespace eTeatar.Web.Controllers
{
    public class NovostiController : Controller
    {
        private readonly MojContext _context;

        public NovostiController(MojContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(int page = 1)
        {
            IOrderedQueryable<Obavijest> query = _context.Obavijest.AsNoTracking()
                .OrderByDescending(o => o.DatumVrijeme);
            PagingList<Obavijest> Model = await PagingList.CreateAsync(query, 8, page);

            ViewData["IsLoggedIn"] = string.IsNullOrEmpty(HttpContext.User.Identity.Name);

            return View(Model);
        }

        [Route("Novosti/Detalji/{id}")]
        public IActionResult Detalji(int id)
        {
            DetaljiVM Model = _context.Obavijest.Where(w => w.Id == id).Select(s =>
                new DetaljiVM
                {
                    NovostId = id,
                    DatumObjaviljavanja = s.DatumVrijeme.ToString("dd.MM.yyyy, HH:mm"),
                    Naziv = s.Naslov,
                    Sadrzaj = s.Sadrzaj,
                    Komentari = _context.Komentar.Where(w => w.ObavijestId == s.Id).Select(q => new Komentar
                    {
                        Sadrzaj = q.Sadrzaj,
                        Username = q.Kupac.Username,
                        Avatar = q.Kupac.Avatar.Link
                    }).ToList(),
                    IsLoggedIn = string.IsNullOrEmpty(HttpContext.User.Identity.Name),
                    MojAvatar = string.IsNullOrEmpty(HttpContext.User.Identity.Name)
                        ? ""
                        : _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name).Avatar.Link,
                    SlikaLink = s.SlikaLink
                }
            ).First();

            return View(Model);
        }

        public IActionResult OstaviKomentar(string komentar, int id)
        {
            _context.Komentar.Add(new Data.Models.Komentar
            {
                DatumVrijeme = DateTime.Now,
                KupacId = _context.Kupac.First(w => w.Username == HttpContext.User.Identity.Name).Id,
                ObavijestId = id,
                Sadrzaj = komentar
            });
            _context.SaveChanges();
            return Redirect("~/Novosti/Detalji/" + id);
        }
    }
}