using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class TipSjedista : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }

        [Required]
        public float CijenaKarteMultiplier { get; set; }

        //Sve dvorane sa tipom sjedista
        public virtual ICollection<DvoranaTipSjedista> DvoranaTipSjedista { get; set; }

        public bool IsDeleted { get; set; }
    }
}
