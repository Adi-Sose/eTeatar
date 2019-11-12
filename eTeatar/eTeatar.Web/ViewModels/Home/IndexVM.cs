using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Home
{
    public class IndexVM : LoggedInVM
    {

        public List<Predstava> Predstave { get; set; }
        public List<KalendarCelija> KalendarCelije { get; set; }

        public Novost GlavnaNovost { get; set; }

        public List<Novost> SporedneNovosti { get; set; }


        public class KalendarCelija
        {
            public string Datum { get; set; }
            public string BrojPredstava { get; set; }
        }

        public class Predstava
        {
            public int Id { get; set; }
            public string Naslov { get; set; }
            public string SlikaLink { get; set; }
            public string Zanrovi { get; set; }
        }

        public class Novost
        {
            public string SlikaLink { get; set; }
            public int Id { get; set; }
            public string Naslov { get; set; }
            public string GlavnaNovostOpis { get; set; }
        }
    }
}
