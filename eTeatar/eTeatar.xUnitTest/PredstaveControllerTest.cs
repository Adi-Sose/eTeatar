using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using eTeatar.Data;
using eTeatar.Data.Models;
using eTeatar.Web.Controllers;
using eTeatar.Web.ViewModels.Predstave;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Zanr = eTeatar.Web.ViewModels.Predstave.Zanr;

namespace eTeatar.xUnitTest
{
    public class PredstaveControllerTest
    {
        private readonly PredstaveController _predstaveController;

        public PredstaveControllerTest()
        {
            #region DBContext

            MojContext Context = new MojContext(new DbContextOptionsBuilder<MojContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

            #endregion

            #region Identity

            UserManager<Korisnik> UserManager = new UserManager<Korisnik>(
                new UserStore<Korisnik>(Context),
                null,
                new PasswordHasher<Korisnik>(),
                new List<UserValidator<Korisnik>> {new UserValidator<Korisnik>()},
                null, null, null, null,
                new Mock<ILogger<UserManager<Korisnik>>>().Object
            );

            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(Context),
                new List<RoleValidator<IdentityRole>> {new RoleValidator<IdentityRole>()},
                null, null,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object
            );

            #endregion

            #region ControllerContext

            // ReSharper disable once ConstantConditionalAccessQualifier
            Context?.PopuniPodacimaAsync(UserManager, RoleManager);

            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "KorisnikKupac1"),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim("name", "KorisnikKupac1")
            };

            ClaimsIdentity Identity = new ClaimsIdentity(Claims, "TestAuthType");
            ClaimsPrincipal ClaimsPrincipal = new ClaimsPrincipal(Identity);

            Mock<IPrincipal> MockPrincipal = new Mock<IPrincipal>();
            MockPrincipal.Setup(x => x.Identity).Returns(Identity);
            MockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            Mock<HttpContext> MockHttpContext = new Mock<HttpContext>();
            MockHttpContext.Setup(m => m.User).Returns(ClaimsPrincipal);

            ControllerContext ControllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.Object
            };

            #endregion

            #region Controller

            _predstaveController = new PredstaveController(Context)
            {
                ControllerContext = ControllerContext
            };

            #endregion
        }

        [Fact]
        public void IndexBrojZanrova()
        {
            ViewResult Result = Assert.IsType<ViewResult>(_predstaveController.Index());
            IndexVM Model = Assert.IsType<IndexVM>(Result.Model);

            Assert.Equal(8, Model.Zanrovi.Count);
        }


        [Fact]
        public void IndexAjaxOcjena()
        {
            PartialViewResult Result = Assert.IsType<PartialViewResult>(_predstaveController.IndexAjax(new IndexVM
            {
                Rating = 3
            }));

            IndexAjaxVM Model = Assert.IsType<IndexAjaxVM>(Result.Model);

            Assert.Equal(2, Model.Predstave.Count);
        }

        [Fact]
        public void IndexAjaxSearch()
        {
            PartialViewResult Result = Assert.IsType<PartialViewResult>(_predstaveController.IndexAjax(new IndexVM
            {
                Search = "1"
            }));

            IndexAjaxVM Model = Assert.IsType<IndexAjaxVM>(Result.Model);

            Assert.Single(Model.Predstave);
        }

        [Fact]
        public void IndexAjaxZanr()
        {
            PartialViewResult Result = Assert.IsType<PartialViewResult>(_predstaveController.IndexAjax(new IndexVM
            {
                Zanrovi = new List<Zanr>
                {
                    new Zanr {Id = 1, Oznacen = true},
                    new Zanr {Id = 2, Oznacen = false},
                    new Zanr {Id = 3, Oznacen = false},
                    new Zanr {Id = 4, Oznacen = false},
                    new Zanr {Id = 5, Oznacen = false},
                    new Zanr {Id = 6, Oznacen = true},
                    new Zanr {Id = 7, Oznacen = false},
                    new Zanr {Id = 8, Oznacen = false}
                }
            }));

            IndexAjaxVM Model = Assert.IsType<IndexAjaxVM>(Result.Model);

            Assert.Equal(5, Model.Predstave.Count);
        }

        [Fact]
        public void DetaljiNaziv()
        {
            ViewResult Result = Assert.IsType<ViewResult>(_predstaveController.Detalji(3));
            DetaljiVM Model = Assert.IsType<DetaljiVM>(Result.Model);

            Assert.Equal("Predstava3", Model.Naziv);
        }

        [Fact]
        public void DetaljiBrojGlumaca()
        {
            ViewResult Result = Assert.IsType<ViewResult>(_predstaveController.Detalji(6));
            DetaljiVM Model = Assert.IsType<DetaljiVM>(Result.Model);

            Assert.Equal(7, Model.Uloge.Count);
        }


        [Fact]
        public void DetaljiBrojTermina()
        {
            ViewResult Result = Assert.IsType<ViewResult>(_predstaveController.Detalji(1));
            DetaljiVM Model = Assert.IsType<DetaljiVM>(Result.Model);

            Assert.Equal(9, Model.Termini.Count);
        }
    }
}