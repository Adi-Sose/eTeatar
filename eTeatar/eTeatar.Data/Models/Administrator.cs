using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTeatar.Data.Models
{
    public class Administrator
    {
        public int AdministratorId { get; set; }

        //Nalog
        [ForeignKey("Korisnik")]
        public string KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        //Username zbog lakse pretrage
        public string Username { get; set; }

        //Sve obavijesti koje je Administrator objavio
        public virtual ICollection<Obavijest> Obavijesti { get; set; }
    }
}
