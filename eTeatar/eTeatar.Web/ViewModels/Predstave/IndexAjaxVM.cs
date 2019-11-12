using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Predstave
{
    public class IndexAjaxVM { 
        public List<Predstava> Predstave { get; set; }

        public class Predstava
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public string OcjenaLink { get; set; }
            public double Ocjena { get; set; }
            public string Zanrovi { get; set; }
            public string GlavnaUloga { get; set; }
            public string SlikaLink { get; set; }
        }
    }
}
