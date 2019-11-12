using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.User
{
    public class VerifikacijaBrojaVM
    {
        [Required(ErrorMessage ="Unesite Verifikacijski broj!")]  
        public string VerifikacijskiBroj { get; set; }
    }
}
