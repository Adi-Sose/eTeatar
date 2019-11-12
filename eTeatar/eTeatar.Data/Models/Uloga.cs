using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Uloga : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Naziv { get; set; }
        //True ukoliko je uloga glavna
        [Required]
        public bool IsGlavnaUloga { get; set; }

        //Predstava u kojoj
        [Required]
        public int PredstavaId { get; set; }
        public virtual Predstava Predstava { get; set; }

        //Glumac ima ulogu
        [Required]
        public int GlumacId { get; set; }
        public  Glumac Glumac { get; set; }

        public bool IsDeleted { get; set; }
    }
}
