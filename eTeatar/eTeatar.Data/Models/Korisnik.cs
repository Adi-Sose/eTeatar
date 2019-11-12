using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTeatar.Data.Models
{
    public class Korisnik : IdentityUser, IIsDeleted
    {

        public int? KorisnikId { get; set; }
        public virtual Kupac Kupac { get; set; }


        public int? AdministratorId { get; set; }
        public virtual Administrator Administrator { get; set; }

        public bool IsDeleted { get; set; }
    }
}
