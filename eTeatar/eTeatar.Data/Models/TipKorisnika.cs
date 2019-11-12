using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class TipKorisnika : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        [Required]
        public int Cijena { get; set; }
        [Required]
        [Range(0,1)]
        public float CijenaKartePopust { get; set; }
        public int? IduciTipKorisnikaId { get; set; }
        public virtual TipKorisnika IduciTipKorisnika { get; set; }

        public bool IsOsnovni { get; set; }

        public bool IsDeleted { get; set; }
    }
}
