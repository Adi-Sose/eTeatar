using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.User
{
    public class UserLoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Unesite password!")]
        public string Password { get; set; }

        public string Error { get; set; }
    }
}
