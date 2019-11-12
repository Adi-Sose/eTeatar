using System;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Komentar : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        //Datum i vrijeme kada je korisnik ostavio komentar
        public DateTime DatumVrijeme { get; set;}

        [Required]
        [StringLength(1024)]
        public string Sadrzaj { get; set; }

        //Korisnik koji je ostavio komentar
        [Required]
        public int KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }

        //Obavijest na kojoj se komentar nalazi
        [Required]
        public int ObavijestId { get; set; }
        public virtual Obavijest Obavijest { get; set; }
        public bool IsDeleted { get; set; }
    }
}
