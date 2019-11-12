using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Predstave
{
    public class DetaljiVM : LoggedInVM
    {
        public string Naziv { get; set; }
        public string Zanrovi { get; set; }
        public string Ocjena { get; set; }
        public string GlavniGlumac { get; set; }
        public string Reziser { get; set; }
        public string IzvornoDjelo { get; set; }
        public string Opis { get; set; }
        public List<Uloga> Uloge { get; set; }
        public List<Termin> Termini { get; set; }
        public string SlikaLink { get; set; }

        public class Uloga
        {
            public string UlogaNaziv { get; set; }
            public string Glumac { get; set; }
        }

        public class Termin
        {
            public string Grad { get; set; }
            public string Datum { get; set; }
            public string Teatar { get; set; }
            public int TerminId { get; set; }
        }

    }
}
