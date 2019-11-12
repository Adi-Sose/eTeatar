using System;
using System.Collections.Generic;
using System.Linq;
using eTeatar.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTeatar.Data
{
    public class MojDBInitializer
    {
        public static async System.Threading.Tasks.Task IzvrsiAsync(MojContext _context, UserManager<Korisnik> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            
            _context.Grad.Add(new Grad { Id = 1, Naziv = "Grad", IsDeleted = false, Kupci = null, Teatari = null });
            _context.Database.OpenConnection();
            try
            {
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Grad ON");
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Grad OFF");
            }
            finally
            {
                _context.Database.CloseConnection();
            }

            Grad Grad1 = new Grad {Naziv = "Grad1" };
            Grad Grad2 = new Grad {Naziv = "Grad2" };
            Grad Grad3 = new Grad {Naziv = "Grad3" };
            Grad Grad4 = new Grad {Naziv = "Grad4" };

            _context.Grad.Add(Grad1);
            _context.Grad.Add(Grad2);
            _context.Grad.Add(Grad3);
            _context.Grad.Add(Grad4);
            _context.SaveChanges();


            Teatar Teatar1 = new Teatar { Grad = Grad1, Naziv = "Teatar1" };
            Teatar Teatar2 = new Teatar { Grad = Grad1, Naziv = "Teatar2" };
            Teatar Teatar3 = new Teatar { Grad = Grad2, Naziv = "Teatar3" };
            Teatar Teatar4 = new Teatar { Grad = Grad2, Naziv = "Teatar4" };

            _context.Teatar.Add(Teatar1);
            _context.Teatar.Add(Teatar2);
            _context.Teatar.Add(Teatar3);
            _context.Teatar.Add(Teatar4);
            _context.SaveChanges();


            Dvorana Dvorana1 = new Dvorana { Naziv = "Dvorana1", Teatar = Teatar1 };
            Dvorana Dvorana2 = new Dvorana { Naziv = "Dvorana2", Teatar = Teatar1 };
            Dvorana Dvorana3 = new Dvorana { Naziv = "Dvorana3", Teatar = Teatar1 };
            Dvorana Dvorana4 = new Dvorana { Naziv = "Dvorana4", Teatar = Teatar1 };
            Dvorana Dvorana5 = new Dvorana { Naziv = "Dvorana5", Teatar = Teatar2 };
            Dvorana Dvorana6 = new Dvorana { Naziv = "Dvorana6", Teatar = Teatar2 };
            Dvorana Dvorana7 = new Dvorana { Naziv = "Dvorana7", Teatar = Teatar2 };
            Dvorana Dvorana8 = new Dvorana { Naziv = "Dvorana8", Teatar = Teatar2 };

            _context.Dvorana.Add(Dvorana1);
            _context.Dvorana.Add(Dvorana2);
            _context.Dvorana.Add(Dvorana3);
            _context.Dvorana.Add(Dvorana4);
            _context.Dvorana.Add(Dvorana5);
            _context.Dvorana.Add(Dvorana6);
            _context.Dvorana.Add(Dvorana7);
            _context.Dvorana.Add(Dvorana8);
            _context.SaveChanges();


            TipSjedista TipSjedista1 = new TipSjedista { Naziv = "TipSjedista1", CijenaKarteMultiplier = 1.0f };
            TipSjedista TipSjedista2 = new TipSjedista { Naziv = "TipSjedista2", CijenaKarteMultiplier = 2.0f };
            TipSjedista TipSjedista3 = new TipSjedista { Naziv = "TipSjedista3", CijenaKarteMultiplier = 3.0f };
            TipSjedista TipSjedista4 = new TipSjedista { Naziv = "TipSjedista4", CijenaKarteMultiplier = 4.0f };
            TipSjedista TipSjedista5 = new TipSjedista { Naziv = "TipSjedista5", CijenaKarteMultiplier = 5.0f };

            _context.TipSjedista.Add(TipSjedista1);
            _context.TipSjedista.Add(TipSjedista2);
            _context.TipSjedista.Add(TipSjedista3);
            _context.TipSjedista.Add(TipSjedista4);
            _context.TipSjedista.Add(TipSjedista5);
            _context.SaveChanges();


            DvoranaTipSjedista DvoranaTipSjedista1 = new DvoranaTipSjedista  { Dvorana = Dvorana1, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista2 = new DvoranaTipSjedista  { Dvorana = Dvorana2, TipSjedista = TipSjedista1, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista3 = new DvoranaTipSjedista  { Dvorana = Dvorana3, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista4 = new DvoranaTipSjedista  { Dvorana = Dvorana4, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista5 = new DvoranaTipSjedista  { Dvorana = Dvorana5, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista6 = new DvoranaTipSjedista  { Dvorana = Dvorana6, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista7 = new DvoranaTipSjedista  { Dvorana = Dvorana7, TipSjedista = TipSjedista1, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista8 = new DvoranaTipSjedista  { Dvorana = Dvorana8, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista9 = new DvoranaTipSjedista  { Dvorana = Dvorana1, TipSjedista = TipSjedista2, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista10 = new DvoranaTipSjedista { Dvorana = Dvorana2, TipSjedista = TipSjedista2, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista11 = new DvoranaTipSjedista { Dvorana = Dvorana3, TipSjedista = TipSjedista2, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista12 = new DvoranaTipSjedista { Dvorana = Dvorana4, TipSjedista = TipSjedista2, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista13 = new DvoranaTipSjedista { Dvorana = Dvorana5, TipSjedista = TipSjedista2, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista14 = new DvoranaTipSjedista { Dvorana = Dvorana6, TipSjedista = TipSjedista2, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista15 = new DvoranaTipSjedista { Dvorana = Dvorana7, TipSjedista = TipSjedista2, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista16 = new DvoranaTipSjedista { Dvorana = Dvorana8, TipSjedista = TipSjedista2, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista17 = new DvoranaTipSjedista { Dvorana = Dvorana1, TipSjedista = TipSjedista3, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista18 = new DvoranaTipSjedista { Dvorana = Dvorana2, TipSjedista = TipSjedista3, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista19 = new DvoranaTipSjedista { Dvorana = Dvorana3, TipSjedista = TipSjedista3, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista20 = new DvoranaTipSjedista { Dvorana = Dvorana4, TipSjedista = TipSjedista3, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista21 = new DvoranaTipSjedista { Dvorana = Dvorana5, TipSjedista = TipSjedista3, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista22 = new DvoranaTipSjedista { Dvorana = Dvorana6, TipSjedista = TipSjedista3, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista23 = new DvoranaTipSjedista { Dvorana = Dvorana7, TipSjedista = TipSjedista3, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista24 = new DvoranaTipSjedista { Dvorana = Dvorana8, TipSjedista = TipSjedista3, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista25 = new DvoranaTipSjedista { Dvorana = Dvorana1, TipSjedista = TipSjedista4, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista26 = new DvoranaTipSjedista { Dvorana = Dvorana2, TipSjedista = TipSjedista4, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista27 = new DvoranaTipSjedista { Dvorana = Dvorana3, TipSjedista = TipSjedista4, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista28 = new DvoranaTipSjedista { Dvorana = Dvorana4, TipSjedista = TipSjedista4, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista29 = new DvoranaTipSjedista { Dvorana = Dvorana5, TipSjedista = TipSjedista4, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista30 = new DvoranaTipSjedista { Dvorana = Dvorana6, TipSjedista = TipSjedista4, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista31 = new DvoranaTipSjedista { Dvorana = Dvorana7, TipSjedista = TipSjedista4, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista32 = new DvoranaTipSjedista { Dvorana = Dvorana8, TipSjedista = TipSjedista4, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista33 = new DvoranaTipSjedista { Dvorana = Dvorana1, TipSjedista = TipSjedista5, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista34 = new DvoranaTipSjedista { Dvorana = Dvorana2, TipSjedista = TipSjedista5, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista35 = new DvoranaTipSjedista { Dvorana = Dvorana3, TipSjedista = TipSjedista5, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista36 = new DvoranaTipSjedista { Dvorana = Dvorana4, TipSjedista = TipSjedista5, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista37 = new DvoranaTipSjedista { Dvorana = Dvorana5, TipSjedista = TipSjedista5, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista38 = new DvoranaTipSjedista { Dvorana = Dvorana6, TipSjedista = TipSjedista5, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista39 = new DvoranaTipSjedista { Dvorana = Dvorana7, TipSjedista = TipSjedista5, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista40 = new DvoranaTipSjedista { Dvorana = Dvorana8, TipSjedista = TipSjedista5, BrojSjedista = 15 };

            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista1);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista2);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista3);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista4);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista5);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista6);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista7);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista8);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista9);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista10);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista11);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista12);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista13);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista14);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista15);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista16);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista17);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista18);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista19);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista20);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista21);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista22);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista23);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista24);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista25);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista26);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista27);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista28);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista29);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista30);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista31);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista32);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista33);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista34);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista35);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista36);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista37);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista38);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista39);
            _context.DvoranaTipSjedista.Add(DvoranaTipSjedista40);
            _context.SaveChanges();


            Predstava Predstava1 = new Predstava { Naziv = "Predstava1", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava2 = new Predstava { Naziv = "Predstava2", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava3 = new Predstava { Naziv = "Predstava3", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava4 = new Predstava { Naziv = "Predstava4", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava5 = new Predstava { Naziv = "Predstava5", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava6 = new Predstava { Naziv = "Predstava6", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava7 = new Predstava { Naziv = "Predstava7", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava8 = new Predstava { Naziv = "Predstava8", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };

            _context.Predstava.Add(Predstava1);
            _context.Predstava.Add(Predstava2);
            _context.Predstava.Add(Predstava3);
            _context.Predstava.Add(Predstava4);
            _context.Predstava.Add(Predstava5);
            _context.Predstava.Add(Predstava6);
            _context.Predstava.Add(Predstava7);
            _context.Predstava.Add(Predstava8);
            _context.SaveChanges();


            Zanr Zanr1 = new Zanr { Naziv = "Zanr1" };
            Zanr Zanr2 = new Zanr { Naziv = "Zanr2" };
            Zanr Zanr3 = new Zanr { Naziv = "Zanr3" };
            Zanr Zanr4 = new Zanr { Naziv = "Zanr4" };
            Zanr Zanr5 = new Zanr { Naziv = "Zanr5" };
            Zanr Zanr6 = new Zanr { Naziv = "Zanr6" };
            Zanr Zanr7 = new Zanr { Naziv = "Zanr7" };
            Zanr Zanr8 = new Zanr { Naziv = "Zanr8" };

            _context.Zanr.Add(Zanr1);
            _context.Zanr.Add(Zanr2);
            _context.Zanr.Add(Zanr3);
            _context.Zanr.Add(Zanr4);
            _context.Zanr.Add(Zanr5);
            _context.Zanr.Add(Zanr6);
            _context.Zanr.Add(Zanr7);
            _context.Zanr.Add(Zanr8);


            Glumac Glumac1 = new Glumac  { Ime = "GlumacIme1", Prezime = "GlumacPrezime1" };
            Glumac Glumac2 = new Glumac  { Ime = "GlumacIme2", Prezime = "GlumacPrezime2" };
            Glumac Glumac3 = new Glumac  { Ime = "GlumacIme3", Prezime = "GlumacPrezime3" };
            Glumac Glumac4 = new Glumac  { Ime = "GlumacIme4", Prezime = "GlumacPrezime4" };
            Glumac Glumac5 = new Glumac  { Ime = "GlumacIme5", Prezime = "GlumacPrezime5" };
            Glumac Glumac6 = new Glumac  { Ime = "GlumacIme6", Prezime = "GlumacPrezime6" };
            Glumac Glumac7 = new Glumac  { Ime = "GlumacIme7", Prezime = "GlumacPrezime7" };
            Glumac Glumac8 = new Glumac  { Ime = "GlumacIme8", Prezime = "GlumacPrezime8" };
            Glumac Glumac9 = new Glumac  { Ime = "GlumacIme9", Prezime = "GlumacPrezime8" };
            Glumac Glumac10 = new Glumac { Ime = "GlumacIme10", Prezime = "GlumacPrezime10" };

            _context.Glumac.Add(Glumac1);
            _context.Glumac.Add(Glumac2);
            _context.Glumac.Add(Glumac3);
            _context.Glumac.Add(Glumac4);
            _context.Glumac.Add(Glumac5);
            _context.Glumac.Add(Glumac6);
            _context.Glumac.Add(Glumac7);
            _context.Glumac.Add(Glumac8);
            _context.Glumac.Add(Glumac9);
            _context.Glumac.Add(Glumac10);
            _context.SaveChanges();


            PredstavaZanr PredstavaZanr1 = new PredstavaZanr  { Predstava = Predstava1, Zanr = Zanr1 };
            PredstavaZanr PredstavaZanr2 = new PredstavaZanr  { Predstava = Predstava1, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr3 = new PredstavaZanr  { Predstava = Predstava1, Zanr = Zanr3 };
            PredstavaZanr PredstavaZanr4 = new PredstavaZanr  { Predstava = Predstava2, Zanr = Zanr4 };
            PredstavaZanr PredstavaZanr5 = new PredstavaZanr  { Predstava = Predstava2, Zanr = Zanr5 };
            PredstavaZanr PredstavaZanr6 = new PredstavaZanr  { Predstava = Predstava2, Zanr = Zanr6 };
            PredstavaZanr PredstavaZanr7 = new PredstavaZanr  { Predstava = Predstava3, Zanr = Zanr7 };
            PredstavaZanr PredstavaZanr8 = new PredstavaZanr  { Predstava = Predstava3, Zanr = Zanr8 };
            PredstavaZanr PredstavaZanr9 = new PredstavaZanr  { Predstava = Predstava4, Zanr = Zanr1 };
            PredstavaZanr PredstavaZanr10 = new PredstavaZanr { Predstava = Predstava4, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr11 = new PredstavaZanr { Predstava = Predstava5, Zanr = Zanr1 };
            PredstavaZanr PredstavaZanr12 = new PredstavaZanr { Predstava = Predstava5, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr13 = new PredstavaZanr { Predstava = Predstava5, Zanr = Zanr3 };
            PredstavaZanr PredstavaZanr14 = new PredstavaZanr { Predstava = Predstava5, Zanr = Zanr4 };
            PredstavaZanr PredstavaZanr15 = new PredstavaZanr { Predstava = Predstava5, Zanr = Zanr5 };
            PredstavaZanr PredstavaZanr16 = new PredstavaZanr { Predstava = Predstava6, Zanr = Zanr1 };
            PredstavaZanr PredstavaZanr17 = new PredstavaZanr { Predstava = Predstava6, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr18 = new PredstavaZanr { Predstava = Predstava7, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr19 = new PredstavaZanr { Predstava = Predstava8, Zanr = Zanr3 };
            PredstavaZanr PredstavaZanr20 = new PredstavaZanr { Predstava = Predstava8, Zanr = Zanr4 };

            _context.PredstavaZanr.Add(PredstavaZanr1);
            _context.PredstavaZanr.Add(PredstavaZanr2);
            _context.PredstavaZanr.Add(PredstavaZanr3);
            _context.PredstavaZanr.Add(PredstavaZanr4);
            _context.PredstavaZanr.Add(PredstavaZanr5);
            _context.PredstavaZanr.Add(PredstavaZanr6);
            _context.PredstavaZanr.Add(PredstavaZanr7);
            _context.PredstavaZanr.Add(PredstavaZanr8);
            _context.PredstavaZanr.Add(PredstavaZanr9);
            _context.PredstavaZanr.Add(PredstavaZanr10);
            _context.PredstavaZanr.Add(PredstavaZanr11);
            _context.PredstavaZanr.Add(PredstavaZanr12);
            _context.PredstavaZanr.Add(PredstavaZanr13);
            _context.PredstavaZanr.Add(PredstavaZanr14);
            _context.PredstavaZanr.Add(PredstavaZanr15);
            _context.PredstavaZanr.Add(PredstavaZanr16);
            _context.PredstavaZanr.Add(PredstavaZanr17);
            _context.PredstavaZanr.Add(PredstavaZanr18);
            _context.PredstavaZanr.Add(PredstavaZanr19);
            _context.PredstavaZanr.Add(PredstavaZanr20);
            _context.SaveChanges();


            Uloga Uloga1 = new Uloga  { Naziv = "Uloga1", Predstava = Predstava1, Glumac = Glumac1, IsGlavnaUloga = true };
            Uloga Uloga2 = new Uloga  { Naziv = "Uloga2", Predstava = Predstava1, Glumac = Glumac2, IsGlavnaUloga = false };
            Uloga Uloga3 = new Uloga  { Naziv = "Uloga3", Predstava = Predstava1, Glumac = Glumac3, IsGlavnaUloga = false };
            Uloga Uloga4 = new Uloga  { Naziv = "Uloga4", Predstava = Predstava1, Glumac = Glumac4, IsGlavnaUloga = false };
            Uloga Uloga5 = new Uloga  { Naziv = "Uloga1", Predstava = Predstava2, Glumac = Glumac5, IsGlavnaUloga = true };
            Uloga Uloga6 = new Uloga  { Naziv = "Uloga2", Predstava = Predstava2, Glumac = Glumac6, IsGlavnaUloga = false };
            Uloga Uloga7 = new Uloga  { Naziv = "Uloga1", Predstava = Predstava3, Glumac = Glumac7, IsGlavnaUloga = true };
            Uloga Uloga8 = new Uloga  { Naziv = "Uloga1", Predstava = Predstava4, Glumac = Glumac8, IsGlavnaUloga = true };
            Uloga Uloga9 = new Uloga  { Naziv = "Uloga2", Predstava = Predstava4, Glumac = Glumac9, IsGlavnaUloga = false };
            Uloga Uloga10 = new Uloga { Naziv = "Uloga1", Predstava = Predstava5, Glumac = Glumac10, IsGlavnaUloga = true };
            Uloga Uloga11 = new Uloga { Naziv = "Uloga1", Predstava = Predstava6, Glumac = Glumac1, IsGlavnaUloga = true };
            Uloga Uloga12 = new Uloga { Naziv = "Uloga2", Predstava = Predstava6, Glumac = Glumac1, IsGlavnaUloga = false };
            Uloga Uloga13 = new Uloga { Naziv = "Uloga3", Predstava = Predstava6, Glumac = Glumac2, IsGlavnaUloga = false };
            Uloga Uloga14 = new Uloga { Naziv = "Uloga4", Predstava = Predstava6, Glumac = Glumac3, IsGlavnaUloga = false };
            Uloga Uloga15 = new Uloga { Naziv = "Uloga5", Predstava = Predstava6, Glumac = Glumac4, IsGlavnaUloga = false };
            Uloga Uloga16 = new Uloga { Naziv = "Uloga6", Predstava = Predstava6, Glumac = Glumac5, IsGlavnaUloga = false };
            Uloga Uloga17 = new Uloga { Naziv = "Uloga7", Predstava = Predstava6, Glumac = Glumac6, IsGlavnaUloga = false };
            Uloga Uloga18 = new Uloga { Naziv = "Uloga1", Predstava = Predstava7, Glumac = Glumac7, IsGlavnaUloga = true };
            Uloga Uloga19 = new Uloga { Naziv = "Uloga2", Predstava = Predstava7, Glumac = Glumac8, IsGlavnaUloga = false };
            Uloga Uloga20 = new Uloga { Naziv = "Uloga3", Predstava = Predstava7, Glumac = Glumac9, IsGlavnaUloga = false };
            Uloga Uloga21 = new Uloga { Naziv = "Uloga1", Predstava = Predstava8, Glumac = Glumac10, IsGlavnaUloga = true };

            _context.Uloga.Add(Uloga1);
            _context.Uloga.Add(Uloga2);
            _context.Uloga.Add(Uloga3);
            _context.Uloga.Add(Uloga4);
            _context.Uloga.Add(Uloga5);
            _context.Uloga.Add(Uloga6);
            _context.Uloga.Add(Uloga7);
            _context.Uloga.Add(Uloga8);
            _context.Uloga.Add(Uloga9);
            _context.Uloga.Add(Uloga10);
            _context.Uloga.Add(Uloga11);
            _context.Uloga.Add(Uloga12);
            _context.Uloga.Add(Uloga13);
            _context.Uloga.Add(Uloga14);
            _context.Uloga.Add(Uloga15);
            _context.Uloga.Add(Uloga16);
            _context.Uloga.Add(Uloga17);
            _context.Uloga.Add(Uloga18);
            _context.Uloga.Add(Uloga19);
            _context.Uloga.Add(Uloga20);
            _context.Uloga.Add(Uloga21);
            _context.SaveChanges();


            DateTime Danas = DateTime.Today;
            DateTime Sutra = DateTime.Today.AddDays(1);
            DateTime Prekosutra = DateTime.Today.AddDays(2);
            DateTime Tri = DateTime.Today.AddDays(3);
            DateTime Cetiri = DateTime.Today.AddDays(4);
            DateTime Pet = DateTime.Today.AddDays(5);
            DateTime Sest = DateTime.Today.AddDays(6);
            DateTime Sedam = DateTime.Today.AddDays(7);

            Termin Termin1 = new Termin  { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(18)};
            Termin Termin2 = new Termin  { Predstava = Predstava2, Dvorana = Dvorana2, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(18)};
            Termin Termin3 = new Termin  { Predstava = Predstava3, Dvorana = Dvorana3, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(20)};
            Termin Termin4 = new Termin  { Predstava = Predstava4, Dvorana = Dvorana4, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(20)};
            Termin Termin5 = new Termin  { Predstava = Predstava5, Dvorana = Dvorana5, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(19)};
            Termin Termin6 = new Termin  { Predstava = Predstava6, Dvorana = Dvorana6, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(19)};
            Termin Termin7 = new Termin  { Predstava = Predstava7, Dvorana = Dvorana7, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(17)};
            Termin Termin8 = new Termin  { Predstava = Predstava8, Dvorana = Dvorana8, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(18)};
            Termin Termin9 = new Termin  { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(18)};
            Termin Termin10 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sutra.AddHours(18)};
            Termin Termin11 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Prekosutra.AddHours(18)};
            Termin Termin12 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Tri.AddHours(18)};
            Termin Termin13 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Cetiri.AddHours(18)};
            Termin Termin14 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Pet.AddHours(18)};
            Termin Termin15 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sest.AddHours(18)};
            Termin Termin16 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sedam.AddHours(18)};

            _context.Termin.Add(Termin1);
            _context.Termin.Add(Termin2);
            _context.Termin.Add(Termin3);
            _context.Termin.Add(Termin4);
            _context.Termin.Add(Termin5);
            _context.Termin.Add(Termin6);
            _context.Termin.Add(Termin7);
            _context.Termin.Add(Termin8);
            _context.Termin.Add(Termin9);
            _context.Termin.Add(Termin10);
            _context.Termin.Add(Termin11);
            _context.Termin.Add(Termin12);
            _context.Termin.Add(Termin13);
            _context.Termin.Add(Termin14);
            _context.Termin.Add(Termin15);
            _context.Termin.Add(Termin16);
            _context.SaveChanges();


            TipKorisnika TipKorisnika4 = new TipKorisnika { Naziv = "TipKorisnika4", Cijena = 50, CijenaKartePopust = 0.5f, IduciTipKorisnika = null };
            TipKorisnika TipKorisnika3 = new TipKorisnika { Naziv = "TipKorisnika3", Cijena = 30, CijenaKartePopust = 0.3f, IduciTipKorisnika = TipKorisnika4 };
            TipKorisnika TipKorisnika2 = new TipKorisnika { Naziv = "TipKorisnika2", Cijena = 10, CijenaKartePopust = 0.1f, IduciTipKorisnika = TipKorisnika3 };
            TipKorisnika TipKorisnika1 = new TipKorisnika { Naziv = "TipKorisnika1", Cijena = 00, CijenaKartePopust = 0.0f, IduciTipKorisnika = TipKorisnika2 , IsOsnovni = true};

            _context.TipKorisnika.Add(TipKorisnika1);
            _context.TipKorisnika.Add(TipKorisnika2);
            _context.TipKorisnika.Add(TipKorisnika3);
            _context.TipKorisnika.Add(TipKorisnika4);
            _context.SaveChanges();


            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac1", Email = "Kupac1@Email.com" }, "Password1!");
            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac2", Email = "Kupac2@Email.com" }, "Password1!");
            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac3", Email = "Kupac3@Email.com" }, "Password1!");
            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac4", Email = "Kupac4@Email.com" }, "Password1!");
            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin1", Email = "Admin1@Email.com" }, "Password1!");
            await _userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin2", Email = "Admin2@Email.com" }, "Password1!");

            await _roleManager.CreateAsync(new IdentityRole { Name = "Kupac", NormalizedName = "Kupac".ToUpper() });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });

            Korisnik Korisnik1 = _context.Korisnik.Where(w => w.UserName == "KorisnikKupac1").First();
            Korisnik Korisnik2 = _context.Korisnik.Where(w => w.UserName == "KorisnikKupac2").First();
            Korisnik Korisnik3 = _context.Korisnik.Where(w => w.UserName == "KorisnikKupac3").First();
            Korisnik Korisnik4 = _context.Korisnik.Where(w => w.UserName == "KorisnikKupac4").First();
            Korisnik Korisnik5 = _context.Korisnik.Where(w => w.UserName == "KorisnikAdmin1").First();
            Korisnik Korisnik6 = _context.Korisnik.Where(w => w.UserName == "KorisnikAdmin2").First();

            await _userManager.AddToRoleAsync(Korisnik1, "Kupac");
            await _userManager.AddToRoleAsync(Korisnik2, "Kupac");
            await _userManager.AddToRoleAsync(Korisnik3, "Kupac");
            await _userManager.AddToRoleAsync(Korisnik4, "Kupac");
            await _userManager.AddToRoleAsync(Korisnik5, "Admin");
            await _userManager.AddToRoleAsync(Korisnik6, "Admin");

            Avatar Avatar1 = new Avatar { Link = "/images/Avatars/Avatar1.png" };
            Avatar Avatar2 = new Avatar { Link = "/images/Avatars/Avatar2.png" };
            Avatar Avatar3 = new Avatar { Link = "/images/Avatars/Avatar3.png" };
            Avatar Avatar4 = new Avatar { Link = "/images/Avatars/Avatar4.png" };
            Avatar Avatar5 = new Avatar { Link = "/images/Avatars/Avatar5.png" };
            Avatar Avatar6 = new Avatar { Link = "/images/Avatars/Avatar6.png" };
            Avatar Avatar7 = new Avatar { Link = "/images/Avatars/Avatar7.png" };
            Avatar Avatar8 = new Avatar { Link = "/images/Avatars/Avatar8.png" };
            Avatar Avatar9 = new Avatar { Link = "/images/Avatars/Avatar9.png" };
            Avatar Avatar10 = new Avatar { Link = "/images/Avatars/Avatar10.png" };
            Avatar Avatar11 = new Avatar { Link = "/images/Avatars/Avatar11.png" };

            _context.Avatar.Add(Avatar1);
            _context.Avatar.Add(Avatar2);
            _context.Avatar.Add(Avatar3);
            _context.Avatar.Add(Avatar4);
            _context.Avatar.Add(Avatar5);
            _context.Avatar.Add(Avatar6);
            _context.Avatar.Add(Avatar7);
            _context.Avatar.Add(Avatar8);
            _context.Avatar.Add(Avatar9);
            _context.Avatar.Add(Avatar10);
            _context.Avatar.Add(Avatar11);
            _context.SaveChanges();

            Kupac Kupac1 = new Kupac { Ime = "KupacIme1", Prezime = "KupacPrezime1", Grad = Grad1, TipKorisnika = TipKorisnika1, Username = Korisnik1.UserName, Korisnik = Korisnik1, Avatar=Avatar1};
            Kupac Kupac2 = new Kupac { Ime = "KupacIme2", Prezime = "KupacPrezime2", Grad = Grad1, TipKorisnika = TipKorisnika2, Username = Korisnik2.UserName, Korisnik = Korisnik1, Avatar=Avatar10};
            Kupac Kupac3 = new Kupac { Ime = "KupacIme3", Prezime = "KupacPrezime3", Grad = Grad2, TipKorisnika = TipKorisnika3, Username = Korisnik3.UserName, Korisnik = Korisnik1, Avatar=Avatar8};
            Kupac Kupac4 = new Kupac { Ime = "KupacIme4", Prezime = "KupacPrezime4", Grad = Grad2, TipKorisnika = TipKorisnika4, Username = Korisnik4.UserName, Korisnik = Korisnik1, Avatar=Avatar4};

            _context.Kupac.Add(Kupac1);
            _context.Kupac.Add(Kupac2);
            _context.Kupac.Add(Kupac3);
            _context.Kupac.Add(Kupac4);
            _context.SaveChanges();

            Administrator Administrator1 = new Administrator { Korisnik = Korisnik5, Username = Korisnik5.UserName };
            Administrator Administrator2 = new Administrator { Korisnik = Korisnik6, Username = Korisnik6.UserName };

            _context.Administrator.Add(Administrator1);
            _context.Administrator.Add(Administrator2);
            _context.SaveChanges();

            await _userManager.CreateAsync(new Korisnik { UserName = "Adi", Email = "Adi@Gmail.com" }, "1");
            Korisnik KorisnikAdi = _context.Korisnik.Where(w => w.UserName == "Adi").First();
            await _userManager.AddToRoleAsync(KorisnikAdi, "Kupac");
            Kupac KupacAdi = new Kupac { Ime = "Adi", Prezime = "Sose", Grad = Grad1, TipKorisnika = TipKorisnika3, Username = KorisnikAdi.UserName, Korisnik = KorisnikAdi, Avatar=Avatar5};
            _context.Kupac.Add(KupacAdi);
            _context.SaveChanges();


            Narudzba Narudzba1 = new Narudzba { Kupac = Kupac1, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };
            Narudzba Narudzba2 = new Narudzba { Kupac = Kupac1, Termin = Termin2, CijenaKarte = 15f, TipSjedista = TipSjedista4 };
            Narudzba Narudzba3 = new Narudzba { Kupac = Kupac2, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };

            _context.Narudzba.Add(Narudzba1);
            _context.Narudzba.Add(Narudzba2);
            _context.Narudzba.Add(Narudzba3);
            _context.SaveChanges();


            Ocjena Ocjena1 = new Ocjena { Narudzba = Narudzba1, Vrijednost = 5, Review = "Review1" };
            Ocjena Ocjena2 = new Ocjena { Narudzba = Narudzba2, Vrijednost = 5, Review = "Review2" };
            Ocjena Ocjena3 = new Ocjena { Narudzba = Narudzba3, Vrijednost = 4, Review = "Review3" };

            _context.Ocjena.Add(Ocjena1);
            _context.Ocjena.Add(Ocjena2);
            _context.Ocjena.Add(Ocjena3);
            _context.SaveChanges();


            Obavijest Obavijest1 = new Obavijest { Naslov = "Obavijest1", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(1) };
            Obavijest Obavijest2 = new Obavijest { Naslov = "Obavijest2", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(2) };
            Obavijest Obavijest3 = new Obavijest { Naslov = "Obavijest3", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(3) };
            Obavijest Obavijest4 = new Obavijest { Naslov = "Obavijest4", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(4) };
            Obavijest Obavijest5 = new Obavijest { Naslov = "Obavijest4", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(5) };

            _context.Obavijest.Add(Obavijest1);
            _context.Obavijest.Add(Obavijest2);
            _context.Obavijest.Add(Obavijest3);
            _context.Obavijest.Add(Obavijest4);
            _context.Obavijest.Add(Obavijest5);
            _context.SaveChanges();


            Komentar Komentar1 = new Komentar { Sadrzaj = "LoremIpsum", Kupac = Kupac1, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(14) };
            Komentar Komentar2 = new Komentar { Sadrzaj = "LoremIpsum", Kupac = Kupac2, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(15) };

            _context.Komentar.Add(Komentar1);
            _context.Komentar.Add(Komentar2);
            _context.SaveChanges();
        }
    }
}
