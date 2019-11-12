using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Termini
{
    public class CheckoutVM
    {
        public int TerminId { get; set; }
        public string Predstava { get; set; }
        public string Grad { get; set; }
        public string Datum { get; set; }
        public string Teatar { get; set; }
        public string Dvorana { get; set; }
        public List<SelectListItem> TipoviSjedista { get; set; }
        public int TipSjedistaId { get; set; }

        [Required(ErrorMessage = "Unesite broj karata!")]
        public int BrojKarata { get; set; }
        public float CijenaKarte { get; set; }
    }
}
