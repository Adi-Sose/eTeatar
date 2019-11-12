using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTeatar.Web.ViewModels.Kupac
{
    public class IndexVM
    {
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string TipKorisnika { get; set; }
        public string IduciTipKorisnika { get; set; }
        public int? IduciTipKorisnikaId { get; set; }
        public List<Narudzba> Narudzbe { get; set; }
        public string Avatar { get; set; }
        public int AvatarId { get; set; }
        public string UserName { get; set; }

    }
    public class Narudzba
    {
        public int Id { get; set; }
        public string Predstava { get; set; }
        public string Datum { get; set; }
        public string Vrijeme { get; set; }
        public string Dvorana { get; set; }
        public string Teatar { get; set; }
        public string Sjediste { get; set; }
        public string BrKarata { get; set; }
        public string Cijena { get; set; }
        public int? Ocjena { get; set; }
    }
}
