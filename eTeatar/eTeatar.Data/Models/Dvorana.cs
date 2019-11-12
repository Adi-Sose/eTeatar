using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Dvorana : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }

        //Teatar u kojem se nalazi dvorana
        [Required]
        public int TeatarId { get; set; }
        public virtual Teatar Teatar { get; set; }

        //Sjedista u dvorani
        public virtual ICollection<DvoranaTipSjedista> DvoranaTipSjedista { get; set; }

        //Svi termini u dvorani
        public virtual ICollection<Termin> Termini { get; set; }
        public bool IsDeleted { get; set; }
    }
}
