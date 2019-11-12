using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Narudzba : IIsDeleted
    {
        public int Id { get; set; }

        //Kupac koji je izvrsio narudzbu
        [Required]
        public int KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }

        //Termin za koji je korisnik kupio kartu
        [Required]
        public int TerminId { get; set; }
        public virtual Termin Termin { get; set; }

        [Required]
        public int TipSjedistaId { get; set; }
        public virtual TipSjedista TipSjedista { get; set; }

        //Cijena koju je kupac platio za kartu
        public float CijenaKarte { get; set; }
        //Broj karata koje je su kupljene
        public int Kolicina { get; set; }

        //Ocjena koju je kupac ostavio za predstavu
        public int? OcjenaId { get; set; }
        public virtual Ocjena Ocjena { get; set; }

        public bool IsDeleted { get; set; }
    }
}
