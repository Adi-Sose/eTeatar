using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Xunit;

namespace eTeatar.xUnitTest
{
    public class NovostiControllerTest
    {
        private MojContext _context;
        private UserManager<Korisnik> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ControllerContext _controllerContext;

        public NovostiControllerTest()
        {
            #region DBContext
            _context = new MojContext(new DbContextOptionsBuilder<MojContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options);
            #endregion

            #region Identity
            _userManager = new UserManager<Korisnik>(
                new UserStore<Korisnik>(_context),
                null,
                new PasswordHasher<Korisnik>(),
                new List<UserValidator<Korisnik>> { new UserValidator<Korisnik>() },
                null, null, null, null,
                new Mock<ILogger<UserManager<Korisnik>>>().Object
                );

            _roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(_context),
                new List<RoleValidator<IdentityRole>> { new RoleValidator<IdentityRole>() },
                null, null,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object
                );
            #endregion

            #region ControllerContext
            _context.PopuniPodacimaAsync(_userManager, _roleManager);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "KorisnikKupac2"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("name", "KorisnikKupac2"),
            };

            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);

            _controllerContext = new ControllerContext
            {
                HttpContext = mockHttpContext.Object
            };
            #endregion

        }

        [Fact]
        public void DetaljiNaslovNovosti()
        {
            NovostiController Controller = new NovostiController(_context)
            {
                ControllerContext = _controllerContext
            };

            var result = Assert.IsType<ViewResult>(Controller.Detalji(2));
            var model = Assert.IsType<Web.ViewModels.Novosti.DetaljiVM>(result.Model);

            Assert.Equal("Obavijest2", model.Naziv);

        }

        /// <summary>
        /// Ostavljanje Komentara
        /// </summary>
        [Fact]
        public void DetaljiOstavljanjeKomentara()
        {
            NovostiController Controller = new NovostiController(_context)
            {
                ControllerContext = _controllerContext
            };
            
            var result1 = Assert.IsType<ViewResult>(Controller.Detalji(1));
            var model1 = Assert.IsType<Web.ViewModels.Novosti.DetaljiVM>(result1.Model);
            var brojKomentara1 = model1.Komentari.Count;

            Controller.OstaviKomentar("NoviKomentar", 1);

            var result2 = Assert.IsType<ViewResult>(Controller.Detalji(1));
            var model2 = Assert.IsType<Web.ViewModels.Novosti.DetaljiVM>(result2.Model);
            var brojKomentara2 = model2.Komentari.Count;

            Assert.Equal(brojKomentara1 + 1, brojKomentara2);
        }

    }
}
