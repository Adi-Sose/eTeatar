using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Obavijest : IIsDeleted
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Naslov { get; set; }
        [Required]
        [StringLength(4096)]
        public string Sadrzaj { get; set; }
        [Required]
        public DateTime DatumVrijeme { get; set; }
        public string SlikaLink { get; set; }

        //Administrator koji je kreirao obavijest
        [Required]
        public int AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        //Svi komentari na obavijesti
        public virtual ICollection<Komentar> Komentari { get; set; }

        public bool IsDeleted { get; set; }
    }
}
