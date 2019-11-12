using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Teatar : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }

        //Grad u kojem se nalazi teatar
        [Required]
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }

        //Dvorane koje se nalaze u teatru
        public virtual ICollection<Dvorana> Dvorane { get; set; }
        public bool IsDeleted { get; set; }
    }
}