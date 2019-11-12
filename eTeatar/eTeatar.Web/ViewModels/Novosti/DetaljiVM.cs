using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Novosti
{
    public class DetaljiVM: LoggedInVM
    {
        public int NovostId { get; set; }
        public string Naziv { get; set; }
        public string Sadrzaj { get; set; }
        public string DatumObjaviljavanja { get; set; }
        public string MojAvatar { get; set; }
        public List<Komentar> Komentari { get; set; }
        public string SlikaLink { get; set; }

    }

    public class Komentar
    {
        public string Username { get; set; }
        public string Sadrzaj { get; set; }
        public string Avatar { get; set; }
    }
}
