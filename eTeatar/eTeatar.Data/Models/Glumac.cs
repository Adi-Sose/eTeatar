using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Glumac : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Ime { get; set; }
        [Required]
        [StringLength(64)]
        public string Prezime { get; set; }

        public string SlikaLink { get; set; }

        //Sve uloge koje ima glumac
        public virtual ICollection<Uloga> Uloge { get; set; }
        public bool IsDeleted { get; set; }
    }
}
