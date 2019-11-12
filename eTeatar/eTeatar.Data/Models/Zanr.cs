using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Zanr : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }

        //Sve predstave koje pripadaju zanru
        public virtual ICollection<PredstavaZanr> PredstavaZanr { get; set; }

        public bool IsDeleted { get; set; }
    }
}
