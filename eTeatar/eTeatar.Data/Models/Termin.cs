using System;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Termin : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        public DateTime DatumVrijeme { get; set; }

        //Predstava koja ce se odrzati
        [Required]
        public int PredstavaId { get; set; }
        public virtual Predstava Predstava { get; set; }

        //Dvorana u kojoj ce se odrzati predstava
        [Required]
        public int DvoranaId { get; set; }
        public virtual Dvorana Dvorana { get; set; }

        //Cijena koja se mnozi sa TipSjedista.CijenaKarteMultiplier i TipKorinika.CijenaKartePopust
        public int BaznaCijenaKarte { get; set; }

        public bool IsDeleted { get; set; }
    }
}
