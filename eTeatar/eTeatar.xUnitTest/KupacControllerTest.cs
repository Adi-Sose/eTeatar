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
    public class KupacControllerTest
    {
        private MojContext _context;
        private UserManager<Korisnik> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ControllerContext _controllerContext;

        public KupacControllerTest()
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
        public void IndexTipKorisnika()
        {
            KupacController Controller = new KupacController(_context)
            {
                ControllerContext = _controllerContext
            };
            
            var result = Assert.IsType<ViewResult>(Controller.Index());
            var model = Assert.IsType<Web.ViewModels.Kupac.IndexVM>(result.Model);

            Assert.Equal("TipKorisnika2", model.TipKorisnika);
        }

        [Fact]
        public void IndexUpdateAvatar()
        {
            KupacController Controller = new KupacController(_context)
            {
                ControllerContext = _controllerContext
            };

            Controller.UpdateAvatar(4);

            var result = Assert.IsType<ViewResult>(Controller.Index());
            var model = Assert.IsType<Web.ViewModels.Kupac.IndexVM>(result.Model);

            Assert.Equal(4, model.AvatarId);
        }

    }
}
