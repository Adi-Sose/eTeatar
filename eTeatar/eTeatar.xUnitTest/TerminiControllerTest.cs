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
    public class TerminiControllerTest
    {
        private MojContext _context;
        private UserManager<Korisnik> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ControllerContext _controllerContext;

        public TerminiControllerTest()
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
        public void IndexBrojTermina()
        {
            TerminiController Controller = new TerminiController(_context)
            {
                ControllerContext = _controllerContext
            };
            
            var result = Assert.IsType<ViewResult>(Controller.Index());
            var model = Assert.IsType<Web.ViewModels.Termini.IndexVM>(result.Model);

            Assert.Equal(16, model.Termini.Count);
        }

        [Fact]
        public void CheckoutiNazivPredstave()
        {
            TerminiController Controller = new TerminiController(_context)
            {
                ControllerContext = _controllerContext
            };

            var result = Assert.IsType<ViewResult>(Controller.Checkout(1));
            var model = Assert.IsType<Web.ViewModels.Termini.CheckoutVM>(result.Model);

            Assert.Equal("Predstava1", model.Predstava);
        }

        [Fact]
        public void CheckoutAjaxUkupnaCijena()
        {
            TerminiController Controller = new TerminiController(_context)
            {
                ControllerContext = _controllerContext
            };

            var result = Assert.IsType<PartialViewResult>(Controller.CheckoutAjax(10,2,5,1));
            var model = Assert.IsType<Web.ViewModels.Termini.CheckoutAjaxVM>(result.Model);

            Assert.Equal("90", model.UkupnaCijena);
        }
    }
}
