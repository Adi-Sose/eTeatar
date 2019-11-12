using eTeatar.Data;
using eTeatar.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eTeatar.xUnitTest
{
    public static class ExtensionMetode
    {

        public static async System.Threading.Tasks.Task PopuniPodacimaAsync (this MojContext context, UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            Grad Grad1 = new Grad { Naziv = "Grad1" };
            Grad Grad2 = new Grad { Naziv = "Grad2" };
            Grad Grad3 = new Grad { Naziv = "Grad3" };
            Grad Grad4 = new Grad { Naziv = "Grad4" };

            context.Grad.Add(Grad1);
            context.Grad.Add(Grad2);
            context.Grad.Add(Grad3);
            context.Grad.Add(Grad4);
            context.SaveChanges();


            Teatar Teatar1 = new Teatar { Grad = Grad1, Naziv = "Teatar1" };
            Teatar Teatar2 = new Teatar { Grad = Grad1, Naziv = "Teatar2" };
            Teatar Teatar3 = new Teatar { Grad = Grad2, Naziv = "Teatar3" };
            Teatar Teatar4 = new Teatar { Grad = Grad2, Naziv = "Teatar4" };

            context.Teatar.Add(Teatar1);
            context.Teatar.Add(Teatar2);
            context.Teatar.Add(Teatar3);
            context.Teatar.Add(Teatar4);
            context.SaveChanges();


            Dvorana Dvorana1 = new Dvorana { Naziv = "Dvorana1", Teatar = Teatar1 };
            Dvorana Dvorana2 = new Dvorana { Naziv = "Dvorana2", Teatar = Teatar1 };
            Dvorana Dvorana3 = new Dvorana { Naziv = "Dvorana3", Teatar = Teatar1 };
            Dvorana Dvorana4 = new Dvorana { Naziv = "Dvorana4", Teatar = Teatar1 };
            Dvorana Dvorana5 = new Dvorana { Naziv = "Dvorana5", Teatar = Teatar2 };
            Dvorana Dvorana6 = new Dvorana { Naziv = "Dvorana6", Teatar = Teatar2 };
            Dvorana Dvorana7 = new Dvorana { Naziv = "Dvorana7", Teatar = Teatar2 };
            Dvorana Dvorana8 = new Dvorana { Naziv = "Dvorana8", Teatar = Teatar2 };

            context.Dvorana.Add(Dvorana1);
            context.Dvorana.Add(Dvorana2);
            context.Dvorana.Add(Dvorana3);
            context.Dvorana.Add(Dvorana4);
            context.Dvorana.Add(Dvorana5);
            context.Dvorana.Add(Dvorana6);
            context.Dvorana.Add(Dvorana7);
            context.Dvorana.Add(Dvorana8);
            context.SaveChanges();


            TipSjedista TipSjedista1 = new TipSjedista { Naziv = "TipSjedista1", CijenaKarteMultiplier = 1.0f };
            TipSjedista TipSjedista2 = new TipSjedista { Naziv = "TipSjedista2", CijenaKarteMultiplier = 2.0f };
            TipSjedista TipSjedista3 = new TipSjedista { Naziv = "TipSjedista3", CijenaKarteMultiplier = 3.0f };
            TipSjedista TipSjedista4 = new TipSjedista { Naziv = "TipSjedista4", CijenaKarteMultiplier = 4.0f };
            TipSjedista TipSjedista5 = new TipSjedista { Naziv = "TipSjedista5", CijenaKarteMultiplier = 5.0f };

            context.TipSjedista.AddRange(TipSjedista1
                                         ,TipSjedista2
                                         ,TipSjedista3
                                         ,TipSjedista4
                                         ,TipSjedista5);
            context.SaveChanges();


            DvoranaTipSjedista DvoranaTipSjedista1 = new DvoranaTipSjedista { Dvorana = Dvorana1, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista2 = new DvoranaTipSjedista { Dvorana = Dvorana2, TipSjedista = TipSjedista1, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista3 = new DvoranaTipSjedista { Dvorana = Dvorana3, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista4 = new DvoranaTipSjedista { Dvorana = Dvorana4, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista5 = new DvoranaTipSjedista { Dvorana = Dvorana5, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista6 = new DvoranaTipSjedista { Dvorana = Dvorana6, TipSjedista = TipSjedista1, BrojSjedista = 15 };
            DvoranaTipSjedista DvoranaTipSjedista7 = new DvoranaTipSjedista { Dvorana = Dvorana7, TipSjedista = TipSjedista1, BrojSjedista = 25 };
            DvoranaTipSjedista DvoranaTipSjedista8 = new DvoranaTipSjedista { Dvorana = Dvorana8, TipSjedista = TipSjedista1, BrojSjedista = 20 };
            DvoranaTipSjedista DvoranaTipSjedista9 = new DvoranaTipSjedista { Dvorana = Dvorana1, TipSjedista = TipSjedista2, BrojSjedista = 20 };
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

            context.DvoranaTipSjedista.Add(DvoranaTipSjedista1);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista2);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista3);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista4);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista5);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista6);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista7);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista8);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista9);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista10);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista11);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista12);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista13);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista14);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista15);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista16);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista17);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista18);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista19);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista20);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista21);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista22);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista23);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista24);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista25);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista26);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista27);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista28);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista29);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista30);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista31);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista32);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista33);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista34);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista35);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista36);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista37);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista38);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista39);
            context.DvoranaTipSjedista.Add(DvoranaTipSjedista40);
            context.SaveChanges();


            Predstava Predstava1 = new Predstava { Naziv = "Predstava1", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava2 = new Predstava { Naziv = "Predstava2", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava3 = new Predstava { Naziv = "Predstava3", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava4 = new Predstava { Naziv = "Predstava4", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava5 = new Predstava { Naziv = "Predstava5", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava6 = new Predstava { Naziv = "Predstava6", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava7 = new Predstava { Naziv = "Predstava7", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };
            Predstava Predstava8 = new Predstava { Naziv = "Predstava8", Opis = "LoremIpsum", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela" };

            context.Predstava.AddRange(Predstava1,
                                        Predstava2,
                                        Predstava3,
                                        Predstava4,
                                        Predstava5,
                                        Predstava6,
                                        Predstava7,
                                        Predstava8);
            context.SaveChanges();


            Zanr Zanr1 = new Zanr { Naziv = "Zanr1" };
            Zanr Zanr2 = new Zanr { Naziv = "Zanr2" };
            Zanr Zanr3 = new Zanr { Naziv = "Zanr3" };
            Zanr Zanr4 = new Zanr { Naziv = "Zanr4" };
            Zanr Zanr5 = new Zanr { Naziv = "Zanr5" };
            Zanr Zanr6 = new Zanr { Naziv = "Zanr6" };
            Zanr Zanr7 = new Zanr { Naziv = "Zanr7" };
            Zanr Zanr8 = new Zanr { Naziv = "Zanr8" };

            context.Zanr.AddRange(Zanr1, Zanr2, Zanr3, Zanr4, Zanr5, Zanr6, Zanr7, Zanr8);
            context.SaveChanges();


            Glumac Glumac1 = new Glumac { Ime = "GlumacIme1", Prezime = "GlumacPrezime1" };
            Glumac Glumac2 = new Glumac { Ime = "GlumacIme2", Prezime = "GlumacPrezime2" };
            Glumac Glumac3 = new Glumac { Ime = "GlumacIme3", Prezime = "GlumacPrezime3" };
            Glumac Glumac4 = new Glumac { Ime = "GlumacIme4", Prezime = "GlumacPrezime4" };
            Glumac Glumac5 = new Glumac { Ime = "GlumacIme5", Prezime = "GlumacPrezime5" };
            Glumac Glumac6 = new Glumac { Ime = "GlumacIme6", Prezime = "GlumacPrezime6" };
            Glumac Glumac7 = new Glumac { Ime = "GlumacIme7", Prezime = "GlumacPrezime7" };
            Glumac Glumac8 = new Glumac { Ime = "GlumacIme8", Prezime = "GlumacPrezime8" };
            Glumac Glumac9 = new Glumac { Ime = "GlumacIme9", Prezime = "GlumacPrezime8" };
            Glumac Glumac10 = new Glumac { Ime = "GlumacIme10", Prezime = "GlumacPrezime10" };

            context.Glumac.Add(Glumac1);
            context.Glumac.Add(Glumac2);
            context.Glumac.Add(Glumac3);
            context.Glumac.Add(Glumac4);
            context.Glumac.Add(Glumac5);
            context.Glumac.Add(Glumac6);
            context.Glumac.Add(Glumac7);
            context.Glumac.Add(Glumac8);
            context.Glumac.Add(Glumac9);
            context.Glumac.Add(Glumac10);
            context.SaveChanges();


            PredstavaZanr PredstavaZanr1 = new PredstavaZanr { Predstava = Predstava1, Zanr = Zanr1 };
            PredstavaZanr PredstavaZanr2 = new PredstavaZanr { Predstava = Predstava1, Zanr = Zanr2 };
            PredstavaZanr PredstavaZanr3 = new PredstavaZanr { Predstava = Predstava1, Zanr = Zanr3 };
            PredstavaZanr PredstavaZanr4 = new PredstavaZanr { Predstava = Predstava2, Zanr = Zanr4 };
            PredstavaZanr PredstavaZanr5 = new PredstavaZanr { Predstava = Predstava2, Zanr = Zanr5 };
            PredstavaZanr PredstavaZanr6 = new PredstavaZanr { Predstava = Predstava2, Zanr = Zanr6 };
            PredstavaZanr PredstavaZanr7 = new PredstavaZanr { Predstava = Predstava3, Zanr = Zanr7 };
            PredstavaZanr PredstavaZanr8 = new PredstavaZanr { Predstava = Predstava3, Zanr = Zanr8 };
            PredstavaZanr PredstavaZanr9 = new PredstavaZanr { Predstava = Predstava4, Zanr = Zanr1 };
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

            context.PredstavaZanr.Add(PredstavaZanr1);
            context.PredstavaZanr.Add(PredstavaZanr2);
            context.PredstavaZanr.Add(PredstavaZanr3);
            context.PredstavaZanr.Add(PredstavaZanr4);
            context.PredstavaZanr.Add(PredstavaZanr5);
            context.PredstavaZanr.Add(PredstavaZanr6);
            context.PredstavaZanr.Add(PredstavaZanr7);
            context.PredstavaZanr.Add(PredstavaZanr8);
            context.PredstavaZanr.Add(PredstavaZanr9);
            context.PredstavaZanr.Add(PredstavaZanr10);
            context.PredstavaZanr.Add(PredstavaZanr11);
            context.PredstavaZanr.Add(PredstavaZanr12);
            context.PredstavaZanr.Add(PredstavaZanr13);
            context.PredstavaZanr.Add(PredstavaZanr14);
            context.PredstavaZanr.Add(PredstavaZanr15);
            context.PredstavaZanr.Add(PredstavaZanr16);
            context.PredstavaZanr.Add(PredstavaZanr17);
            context.PredstavaZanr.Add(PredstavaZanr18);
            context.PredstavaZanr.Add(PredstavaZanr19);
            context.PredstavaZanr.Add(PredstavaZanr20);
            context.SaveChanges();


            Uloga Uloga1 = new Uloga { Naziv = "Uloga1", Predstava = Predstava1, Glumac = Glumac1, IsGlavnaUloga = true };
            Uloga Uloga2 = new Uloga { Naziv = "Uloga2", Predstava = Predstava1, Glumac = Glumac2, IsGlavnaUloga = false };
            Uloga Uloga3 = new Uloga { Naziv = "Uloga3", Predstava = Predstava1, Glumac = Glumac3, IsGlavnaUloga = false };
            Uloga Uloga4 = new Uloga { Naziv = "Uloga4", Predstava = Predstava1, Glumac = Glumac4, IsGlavnaUloga = false };
            Uloga Uloga5 = new Uloga { Naziv = "Uloga1", Predstava = Predstava2, Glumac = Glumac5, IsGlavnaUloga = true };
            Uloga Uloga6 = new Uloga { Naziv = "Uloga2", Predstava = Predstava2, Glumac = Glumac6, IsGlavnaUloga = false };
            Uloga Uloga7 = new Uloga { Naziv = "Uloga1", Predstava = Predstava3, Glumac = Glumac7, IsGlavnaUloga = true };
            Uloga Uloga8 = new Uloga { Naziv = "Uloga1", Predstava = Predstava4, Glumac = Glumac8, IsGlavnaUloga = true };
            Uloga Uloga9 = new Uloga { Naziv = "Uloga2", Predstava = Predstava4, Glumac = Glumac9, IsGlavnaUloga = false };
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

            context.Uloga.Add(Uloga1);
            context.Uloga.Add(Uloga2);
            context.Uloga.Add(Uloga3);
            context.Uloga.Add(Uloga4);
            context.Uloga.Add(Uloga5);
            context.Uloga.Add(Uloga6);
            context.Uloga.Add(Uloga7);
            context.Uloga.Add(Uloga8);
            context.Uloga.Add(Uloga9);
            context.Uloga.Add(Uloga10);
            context.Uloga.Add(Uloga11);
            context.Uloga.Add(Uloga12);
            context.Uloga.Add(Uloga13);
            context.Uloga.Add(Uloga14);
            context.Uloga.Add(Uloga15);
            context.Uloga.Add(Uloga16);
            context.Uloga.Add(Uloga17);
            context.Uloga.Add(Uloga18);
            context.Uloga.Add(Uloga19);
            context.Uloga.Add(Uloga20);
            context.Uloga.Add(Uloga21);
            context.SaveChanges();


            DateTime Danas = DateTime.Today;
            DateTime Sutra = DateTime.Today.AddDays(1);
            DateTime Prekosutra = DateTime.Today.AddDays(2);
            DateTime Tri = DateTime.Today.AddDays(3);
            DateTime Cetiri = DateTime.Today.AddDays(4);
            DateTime Pet = DateTime.Today.AddDays(5);
            DateTime Sest = DateTime.Today.AddDays(6);
            DateTime Sedam = DateTime.Today.AddDays(7);

            Termin Termin1 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(1) };
            Termin Termin2 = new Termin { Predstava = Predstava2, Dvorana = Dvorana2, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(2) };
            Termin Termin3 = new Termin { Predstava = Predstava3, Dvorana = Dvorana3, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(3) };
            Termin Termin4 = new Termin { Predstava = Predstava4, Dvorana = Dvorana4, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(4) };
            Termin Termin5 = new Termin { Predstava = Predstava5, Dvorana = Dvorana5, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(5) };
            Termin Termin6 = new Termin { Predstava = Predstava6, Dvorana = Dvorana6, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(6) };
            Termin Termin7 = new Termin { Predstava = Predstava7, Dvorana = Dvorana7, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(7) };
            Termin Termin8 = new Termin { Predstava = Predstava8, Dvorana = Dvorana8, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(8) };
            Termin Termin9 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Danas.AddHours(9) };
            Termin Termin10 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sutra.AddHours(1) };
            Termin Termin11 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Prekosutra.AddHours(2) };
            Termin Termin12 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Tri.AddHours(3) };
            Termin Termin13 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Cetiri.AddHours(4) };
            Termin Termin14 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Pet.AddHours(5) };
            Termin Termin15 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sest.AddHours(6) };
            Termin Termin16 = new Termin { Predstava = Predstava1, Dvorana = Dvorana1, BaznaCijenaKarte = 10, DatumVrijeme = Sedam.AddHours(7) };
            
            context.Termin.AddRange(Termin1
                                   , Termin2
                                   , Termin3
                                   , Termin4
                                   , Termin5
                                   , Termin6
                                   , Termin7
                                   , Termin8
                                   , Termin9
                                  , Termin10
                                  , Termin11
                                  , Termin12
                                  , Termin13
                                  , Termin14
                                  , Termin15
                                  , Termin16);
            context.SaveChanges();


            TipKorisnika TipKorisnika4 = new TipKorisnika { Naziv = "TipKorisnika4", Cijena = 50, CijenaKartePopust = 0.5f, IduciTipKorisnika = null };
            TipKorisnika TipKorisnika3 = new TipKorisnika { Naziv = "TipKorisnika3", Cijena = 30, CijenaKartePopust = 0.3f, IduciTipKorisnika = TipKorisnika4 };
            TipKorisnika TipKorisnika2 = new TipKorisnika { Naziv = "TipKorisnika2", Cijena = 10, CijenaKartePopust = 0.1f, IduciTipKorisnika = TipKorisnika3 };
            TipKorisnika TipKorisnika1 = new TipKorisnika { Naziv = "TipKorisnika1", Cijena = 00, CijenaKartePopust = 0.0f, IduciTipKorisnika = TipKorisnika2, IsOsnovni = true };

            context.TipKorisnika.AddRange(TipKorisnika1
                                          ,TipKorisnika2
                                          ,TipKorisnika3
                                          ,TipKorisnika4);
            context.SaveChanges();


            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac1", Email = "Kupac1@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac2", Email = "Kupac2@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac3", Email = "Kupac3@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac4", Email = "Kupac4@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin1", Email = "Admin1@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin2", Email = "Admin2@Email.com" }, "Password1!");

            await roleManager.CreateAsync(new IdentityRole { Name = "Kupac", NormalizedName = "Kupac".ToUpper() });
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });

            Korisnik Korisnik1 = context.Korisnik.Where(w => w.UserName == "KorisnikKupac1").First();
            Korisnik Korisnik2 = context.Korisnik.Where(w => w.UserName == "KorisnikKupac2").First();
            Korisnik Korisnik3 = context.Korisnik.Where(w => w.UserName == "KorisnikKupac3").First();
            Korisnik Korisnik4 = context.Korisnik.Where(w => w.UserName == "KorisnikKupac4").First();
            Korisnik Korisnik5 = context.Korisnik.Where(w => w.UserName == "KorisnikAdmin1").First();
            Korisnik Korisnik6 = context.Korisnik.Where(w => w.UserName == "KorisnikAdmin2").First();

            await userManager.AddToRoleAsync(Korisnik1, "Kupac");
            await userManager.AddToRoleAsync(Korisnik2, "Kupac");
            await userManager.AddToRoleAsync(Korisnik3, "Kupac");
            await userManager.AddToRoleAsync(Korisnik4, "Kupac");
            await userManager.AddToRoleAsync(Korisnik5, "Admin");
            await userManager.AddToRoleAsync(Korisnik6, "Admin");

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

            context.Avatar.Add(Avatar1);
            context.Avatar.Add(Avatar2);
            context.Avatar.Add(Avatar3);
            context.Avatar.Add(Avatar4);
            context.Avatar.Add(Avatar5);
            context.Avatar.Add(Avatar6);
            context.Avatar.Add(Avatar7);
            context.Avatar.Add(Avatar8);
            context.Avatar.Add(Avatar9);
            context.Avatar.Add(Avatar10);
            context.Avatar.Add(Avatar11);
            context.SaveChanges();

            Kupac Kupac1 = new Kupac { Ime = "KupacIme1", Prezime = "KupacPrezime1", Grad = Grad1, TipKorisnika = TipKorisnika1, Username = Korisnik1.UserName, Korisnik = Korisnik1, Avatar = Avatar1 };
            Kupac Kupac2 = new Kupac { Ime = "KupacIme2", Prezime = "KupacPrezime2", Grad = Grad1, TipKorisnika = TipKorisnika2, Username = Korisnik2.UserName, Korisnik = Korisnik1, Avatar = Avatar10 };
            Kupac Kupac3 = new Kupac { Ime = "KupacIme3", Prezime = "KupacPrezime3", Grad = Grad2, TipKorisnika = TipKorisnika3, Username = Korisnik3.UserName, Korisnik = Korisnik1, Avatar = Avatar8 };
            Kupac Kupac4 = new Kupac { Ime = "KupacIme4", Prezime = "KupacPrezime4", Grad = Grad2, TipKorisnika = TipKorisnika4, Username = Korisnik4.UserName, Korisnik = Korisnik1, Avatar = Avatar4 };

            context.Kupac.Add(Kupac1);
            context.Kupac.Add(Kupac2);
            context.Kupac.Add(Kupac3);
            context.Kupac.Add(Kupac4);
            context.SaveChanges();

            Administrator Administrator1 = new Administrator { Korisnik = Korisnik5, Username = Korisnik5.UserName };
            Administrator Administrator2 = new Administrator { Korisnik = Korisnik6, Username = Korisnik6.UserName };

            context.Administrator.Add(Administrator1);
            context.Administrator.Add(Administrator2);
            context.SaveChanges();

            Narudzba Narudzba1 = new Narudzba { Kupac = Kupac1, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };
            Narudzba Narudzba2 = new Narudzba { Kupac = Kupac1, Termin = Termin2, CijenaKarte = 15f, TipSjedista = TipSjedista4 };
            Narudzba Narudzba3 = new Narudzba { Kupac = Kupac2, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };

            context.Narudzba.Add(Narudzba1);
            context.Narudzba.Add(Narudzba2);
            context.Narudzba.Add(Narudzba3);
            context.SaveChanges();


            Ocjena Ocjena1 = new Ocjena { Narudzba = Narudzba1, Vrijednost = 5, Review = "Review1" };
            Ocjena Ocjena2 = new Ocjena { Narudzba = Narudzba2, Vrijednost = 5, Review = "Review2" };
            Ocjena Ocjena3 = new Ocjena { Narudzba = Narudzba3, Vrijednost = 4, Review = "Review3" };

            context.Ocjena.Add(Ocjena1);
            context.Ocjena.Add(Ocjena2);
            context.Ocjena.Add(Ocjena3);
            context.SaveChanges();


            Obavijest Obavijest1 = new Obavijest { Naslov = "Obavijest1", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(1) };
            Obavijest Obavijest2 = new Obavijest { Naslov = "Obavijest2", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(2) };
            Obavijest Obavijest3 = new Obavijest { Naslov = "Obavijest3", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(3) };
            Obavijest Obavijest4 = new Obavijest { Naslov = "Obavijest4", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(4) };
            Obavijest Obavijest5 = new Obavijest { Naslov = "Obavijest5", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(5) };

            context.Obavijest.AddRange(Obavijest1
                                       ,Obavijest2
                                       ,Obavijest3
                                       ,Obavijest4
                                       ,Obavijest5);
            context.SaveChanges();


            Komentar Komentar1 = new Komentar { Sadrzaj = "LoremIpsum", Kupac = Kupac1, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(14) };
            Komentar Komentar2 = new Komentar { Sadrzaj = "LoremIpsum", Kupac = Kupac2, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(15) };

            context.Komentar.Add(Komentar1);
            context.Komentar.Add(Komentar2);
            context.SaveChanges();
        }


    }
}
