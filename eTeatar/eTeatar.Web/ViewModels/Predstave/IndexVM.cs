using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Predstave
{
    public class IndexVM : LoggedInVM
    {
        public List<Zanr> Zanrovi { get; set; }
        public string Search { get; set; }
        public bool PredstaveUMomGradu { get; set; }
        public int Rating { get; set; }
    }

    public class Zanr
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Oznacen { get; set; }
    }
}
