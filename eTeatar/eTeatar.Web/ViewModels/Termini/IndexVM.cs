using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Termini
{
    public class IndexVM : LoggedInVM
    {
        public List<Termin> Termini { get; set; }

        public class Termin
        {
            public int TerminId { get; set; }
            public string Predstava { get; set; }
            public string Grad { get; set; }
            public string Datum { get; set; }
            public string Teatar { get; set; }
            public int PredstavaId { get; set; }
        }

    }

}
