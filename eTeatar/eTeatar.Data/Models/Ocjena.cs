using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Ocjena : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        public int Vrijednost { get; set; }
        [StringLength(512)]
        public string Review { get; set; }

        //Narudzba za koju je ocjena vezana (1 Korisnik i 1 Predstava)
        [Required]
        public int NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }

        public bool IsDeleted { get; set; }
    }
}
