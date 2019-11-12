using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.ExtenstionMethods;
using eTeatar.Web.ViewModels.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api;
using Nexmo.Api.Request;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace eTeatar.Web.Controllers
{
    public class UserController : Controller
    {
        #region Protected Members

        /// <summary>
        ///     Pristup bazi podataka
        /// </summary>
        private readonly MojContext _context;

        /// <summary>
        ///     Dodavanje, briasnje, pretraga uloga... Korisnika
        /// </summary>
        private readonly UserManager<Korisnik> _userManager;

        /// <summary>
        ///     Sign in and out
        /// </summary>
        private readonly SignInManager<Korisnik> _signInManager;

        #endregion

        #region Constructor

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public UserController(MojContext context, UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion


        #region Registracija

        #region Kupac

        /// <summary>
        ///     Poziva Register View
        /// </summary>
        /// <returns>Razor page</returns>
        [HttpGet]
        [Route("Register")]
        public IActionResult KupacRegister()
        {
            KupacRegisterVM Model = new KupacRegisterVM
            {
                Gradovi = _context.Grad.Select(s => new SelectListItem {Text = s.Naziv, Value = s.Id.ToString()})
                    .ToList()
            };


            return View(Model);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> KupacRegister(KupacRegisterVM model)
        {
            bool ValidModel = ModelState.IsValid;

            #region Validacija Modela

            if (_context.Korisnik.FirstOrDefault(w => w.UserName == model.Username) != null)
            {
                ModelState.AddModelError("Username", "Username je zauzet!");
                ValidModel = false;
            }


            if (_context.Korisnik.FirstOrDefault(w => w.Email == model.Email) != null)
            {
                ModelState.AddModelError("Email", "Već postoji nalog sa Emailom!");
                ValidModel = false;
            }

            #endregion


            //Povratak na registraciju ukoliko model nije validan
            if (!ValidModel)
            {
                model.Gradovi = _context.Grad.Select(s => new SelectListItem
                {
                    Text = s.Naziv,
                    Value = s.Id.ToString(),
                    Selected = s.Id == model.GradId
                }).ToList();

                model.Password = "";
                model.ConfirmPassword = "";
                return View(model);
            }

            //Logout ukoliko je korisnik vec logovan
            if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name))
                await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            #region Kreiranje naloga

            Korisnik user = new Korisnik
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = "+" + model.PozivniBroj + model.BrojTelefona,
                IsDeleted = true
            };

            await _userManager.CreateAsync(user, model.Password);

            _context.Kupac.Add(new Kupac
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                GradId = model.GradId,
                TipKorisnikaId = _context.TipKorisnika.First(w => w.IsOsnovni).Id,
                KorisnikId = user.Id,
                Username = model.Username,
                IsDeleted = true,
                AvatarId = 11
            });

            _context.SaveChanges();

            Client client = new Client(new Credentials
            {
                ApiKey = "197053f9",
                ApiSecret = "d9I953dwwUbgqdtf"
            });

            NumberVerify.VerifyResponse start = client.NumberVerify.Verify(new NumberVerify.VerifyRequest
            {
                number = "+" + model.PozivniBroj + model.BrojTelefona,
                brand = "eTeatar"
            });

            HttpContext.Session.SetString("RequestId", start.request_id);

            TempData["Username"] = model.Username;
            return View("VerifikacijaBroja");

            #endregion
        }


        [Route("Register/VerifikacijaBroja")]
        public async Task<IActionResult> VerifikacijaBroja(VerifikacijaBrojaVM model)
        {
            Client client = new Client(new Credentials
            {
                ApiKey = "197053f9",
                ApiSecret = "d9I953dwwUbgqdtf"
            });

            NumberVerify.CheckResponse result = client.NumberVerify.Check(new NumberVerify.CheckRequest
            {
                request_id = HttpContext.Session.GetString("RequestId"),
                code = model.VerifikacijskiBroj
            });

            if (result.status != "0")
            {
                ModelState.AddModelError("VerifikacijskiBroj", "Pogresan verifikacijski broj!");
                return View(model);
            }

            string Username = (string) TempData["Username"];

            _context.Korisnik.IgnoreQueryFilters().First(w => w.UserName == Username).IsDeleted = false;
            _context.Kupac.IgnoreQueryFilters().First(w => w.Username == Username).IsDeleted = false;
            _context.SaveChanges();
            //Dodavanje u grupu Kupac
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(Username), "Kupac");

            //Automatski SignIn
            await _signInManager.SignInAsync(_context.Korisnik.First(w => w.UserName == Username), false);

            return Redirect("~/");
        }

        #endregion

        #region Admin

        /// <summary>
        ///     Admin registration
        /// </summary>
        /// <returns>Razor page</returns>
        [Route("/Admin/Register")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminRegister()
        {
            AdminRegisterVM Model = TempData.Get<AdminRegisterVM>("AdminRegisterVM") ?? new AdminRegisterVM();
            TempData.Remove("AdminRegisterVM");
            return View(Model);
        }


        /// <summary>
        ///     Kreira nalog za admina
        /// </summary>
        /// <param name="model">Model sa username, pw</param>
        /// <returns>Redirect na Login</returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminRegister(AdminRegisterVM model)
        {
            bool ValidModel = true;

            #region Validacija Modela

            #region Username

            if (string.IsNullOrEmpty(model.Username))
            {
                model.UsernameError = "Polje za Username ne moze biti prazno";
                ValidModel = false;
            }
            else
            {
                if (_context.Korisnik.FirstOrDefault(w => w.UserName == model.Username) != null)
                {
                    model.UsernameError = "Username vec postoji";
                    ValidModel = false;
                }
                else
                {
                    model.UsernameError = null;
                }
            }

            #endregion

            #region Email

            if (string.IsNullOrEmpty(model.Email))
            {
                model.EmailError = "Polje za Email ne moze biti prazno";
                ValidModel = false;
            }
            else
            {
                if (_context.Korisnik.FirstOrDefault(w => w.Email == model.Email) != null)
                {
                    model.EmailError = "Vec postoji nalog sa email-om";
                    ValidModel = false;
                }
                else
                {
                    model.EmailError = null;
                }
            }

            #endregion

            #region Password

            if (string.IsNullOrEmpty(model.Password))
            {
                model.PasswordError = "Polje za password ne moze biti prazno";
                ValidModel = false;
                model.Password = null;
            }
            else
            {
                if (model.Password != model.ConfirmPassword)
                {
                    model.PasswordError = "Password i Confirm Password moraju biti jednaki";
                    ValidModel = false;
                    model.Password = null;
                }
                else
                {
                    model.PasswordError = null;
                }
            }

            #endregion

            #endregion

            if (!ValidModel)
            {
                model.Password = "";
                model.ConfirmPassword = "";
                TempData.Put("AdminRegisterVM", model);
                return RedirectToAction("AdminRegister");
            }

            #region Kreiranje naloga

            await _userManager.CreateAsync(new Korisnik
            {
                UserName = model.Username,
                Email = model.Email
            }, model.Password);

            _context.Administrator.Add(new Administrator
            {
                KorisnikId = _context.Korisnik.Where(w => w.UserName == model.Username).Select(s => s.Id)
                    .FirstOrDefault(),
                Username = model.Username
            });

            _context.SaveChanges();

            //Dodavanje u grupu Administrator
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(model.Username), "Admin");

            #endregion

            return Redirect("/Admin/Index");
        }

        #endregion

        #endregion

        #region Login

        /// <summary>
        ///     Poziva Login View
        /// </summary>
        /// <returns>Razor page</returns>
        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn()
        {
            UserLoginVM Model = new UserLoginVM();
            return View(Model);
        }

        /// <summary>
        ///     Logira usera
        /// </summary>
        /// <param name="model">Username i password dobijeni is view-a</param>
        /// <returns>Admin/Index ili Homepage. Vraca na login u slucaju greske</returns>
        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(UserLoginVM model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            if (!result.Succeeded)
            {
                model.Error = "Pogresan username i/ili password";
                return View(model);
            }

            if (await _userManager.IsInRoleAsync(_context.Korisnik.First(w => w.UserName == model.Username),
                "Admin"))
                return Redirect("/Admin/Index");
            return Redirect("~/");
        }

        #endregion

        #region Logout

        /// <summary>
        ///     Logs the user out
        /// </summary>
        /// <returns>Redirect to login</returns>
        [Route("Logout")]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Redirect("~/");
        }

        #endregion

        #region AcessDenied

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
    }
}