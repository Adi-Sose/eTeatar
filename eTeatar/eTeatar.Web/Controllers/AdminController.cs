using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eTeatar.Web.ExtenstionMethods;

namespace eTeatar.Web.Controllers
{
    #region Attributes
    [Authorize(Roles = "Admin")]
    #endregion

    public class AdminController : Controller
    {
        #region Private members
        //Preimenuj u db ako si tako navikao
        protected MojContext _context;
        #endregion

        public AdminController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View ();
        }

    }
}