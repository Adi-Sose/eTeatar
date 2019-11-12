using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.User
{
    public class KupacRegisterVM
    {
        [Required(ErrorMessage = "Unesite username!")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Unesite password!")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Unesite password!")]
        [Compare("Password", ErrorMessage = "Passwordi nisu jednaki!")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Unesite ispravan email!")]
        [Required(ErrorMessage = "Unesite email!")]
        public string Email { get; set; }

        public List<SelectListItem> Gradovi { get; set; }

        public int GradId { get; set; }

        [Required(ErrorMessage = "Unesite ime!")]
        [RegularExpression("[A-Za-z]+",ErrorMessage ="Samo slova!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite prezime!")]
        [RegularExpression("[A-Za-z]+",ErrorMessage ="Samo slova!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesite broj telefona!")]
        [RegularExpression("[0-9]+|$", ErrorMessage = "Broj!")]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage = "Unesite pozivni broj!")]
        [RegularExpression("[0-9]+|$", ErrorMessage ="Broj!")]
        public string PozivniBroj { get; set; }
    }
}
