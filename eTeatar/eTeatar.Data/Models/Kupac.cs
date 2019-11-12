using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTeatar.Data.Models
{
    public class Kupac : IIsDeleted
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Ime { get; set; }
        [Required]
        [StringLength(64)]
        public string Prezime { get; set; }

        //Nalog
        [ForeignKey("Korisnik")]
        public string KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        //Username zbog lakse pretrage
        public string Username { get; set; }


        //Grad iz kojeg dolazi korisnik
        [Required]
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }

        //Tip korisnika (npr. Basic, Platinum, Silver...)
        [Required]
        public int TipKorisnikaId { get; set; }
        public virtual TipKorisnika TipKorisnika { get; set; }

        public virtual int AvatarId { get; set; }
        public virtual Avatar Avatar { get; set; }

        //Svi komentari koje je korisnik ostavio
        public virtual ICollection<Komentar> Komentari { get; set; }
        //Sve narudzbe koje je korisnik ostvario
        public virtual ICollection<Narudzba> Narudzbe { get; set; }

        public bool IsDeleted { get; set; }
    }
}
