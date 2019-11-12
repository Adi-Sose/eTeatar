using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Predstava : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }
        [Required]
        [StringLength(64)]
        public string Trajanje { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        [StringLength(128)]
        public string ReziserImePrezime { get; set; }
        [Required]
        [StringLength(128)]
        public string NazivIzvornogDjela { get; set; }
        public string SlikaLink { get; set; }


        //Sve uloge u predstavi
        public virtual ICollection<Uloga> Uloge { get; set; }
        //Svi zanrovi u koje predstava spada
        public virtual ICollection<PredstavaZanr> PredstavaZanr { get; set; }
        //Termini igranja perdstave
        public virtual ICollection<Termin> Termini { get; set; }

        public bool IsDeleted { get; set; }
    }
}
