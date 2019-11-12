using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Grad : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }

        //Svi teatri koji se nalaze u gradu
        public virtual ICollection<Teatar> Teatari { get; set; }
        //Svi korisnici koji dolaze iz grada
        public virtual ICollection<Kupac> Kupci { get; set; }
        public bool IsDeleted { get; set; }
    }
}
