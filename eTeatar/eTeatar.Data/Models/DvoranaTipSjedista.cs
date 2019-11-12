using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class DvoranaTipSjedista : IIsDeleted
    {
        public int DvoranaId { get; set; }
        public virtual Dvorana Dvorana { get; set; }

        public int TipSjedistaId { get; set; }
        public virtual TipSjedista TipSjedista { get; set; }

        [Required]
        public int BrojSjedista { get; set; }

        public bool IsDeleted { get; set; }
    }
}
