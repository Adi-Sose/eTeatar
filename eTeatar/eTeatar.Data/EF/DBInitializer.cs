using System;
using System.Collections.Generic;
using System.Linq;
using eTeatar.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTeatar.Data
{
    public class DBInitializer
    {
        public static async System.Threading.Tasks.Task IzvrsiAsync(MojContext context, UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            context.Grad.Add(new Grad { Id = 1, Naziv = "Grad", IsDeleted = false, Kupci = null, Teatari = null });
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Grad ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Grad OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            Grad Grad1 = new Grad {Naziv = "Sarajevo" };
            Grad Grad2 = new Grad {Naziv = "Mostar" };
            Grad Grad3 = new Grad {Naziv = "Grad3" };
            Grad Grad4 = new Grad {Naziv = "Grad4" };

            context.Grad.AddRange(Grad1,
                                  Grad2,
                                  Grad3,
                                  Grad4);
            context.SaveChanges();


            Teatar Teatar1 = new Teatar {Grad = Grad1, Naziv = "Narodno pozoriste"};
            Teatar Teatar2 = new Teatar {Grad = Grad1, Naziv = "Kamerni Teatar 55"};
            Teatar Teatar3 = new Teatar {Grad = Grad2, Naziv = "Narodno Pozoriste"};
            Teatar Teatar4 = new Teatar {Grad = Grad2, Naziv = "Pozoriste Mladih"};

            context.Teatar.AddRange(Teatar1,
                                    Teatar2,
                                    Teatar3,
                                    Teatar4);
            context.SaveChanges();


            Dvorana Dvorana1 = new Dvorana { Naziv = "Dvorana 1", Teatar = Teatar1 };
            Dvorana Dvorana2 = new Dvorana { Naziv = "Dvorana 2", Teatar = Teatar1 };
            Dvorana Dvorana3 = new Dvorana { Naziv = "Dvorana 1", Teatar = Teatar2 };
            Dvorana Dvorana4 = new Dvorana { Naziv = "Dvorana 2", Teatar = Teatar2 };
            Dvorana Dvorana5 = new Dvorana { Naziv = "Dvorana 1", Teatar = Teatar3 };
            Dvorana Dvorana6 = new Dvorana { Naziv = "Dvorana 2", Teatar = Teatar3 };
            Dvorana Dvorana7 = new Dvorana { Naziv = "Dvorana 1", Teatar = Teatar4 };
            Dvorana Dvorana8 = new Dvorana { Naziv = "Dvorana 2", Teatar = Teatar4 };

            context.Dvorana.AddRange(Dvorana1,
                                     Dvorana2,
                                     Dvorana3,
                                     Dvorana4,
                                     Dvorana5,
                                     Dvorana6,
                                     Dvorana7,
                                     Dvorana8);
            context.SaveChanges();


            TipSjedista TipSjedista1 = new TipSjedista { Naziv = "Galerija", CijenaKarteMultiplier = 1.0f };
            TipSjedista TipSjedista2 = new TipSjedista { Naziv = "Balkon"  , CijenaKarteMultiplier = 2.0f };
            TipSjedista TipSjedista3 = new TipSjedista { Naziv = "Parter"  , CijenaKarteMultiplier = 3.0f };
            TipSjedista TipSjedista4 = new TipSjedista { Naziv = "Loža I"  , CijenaKarteMultiplier = 4.0f };
            TipSjedista TipSjedista5 = new TipSjedista { Naziv = "VIP Loža" , CijenaKarteMultiplier = 5.0f };

            context.TipSjedista.AddRange(TipSjedista1,
                                         TipSjedista2,
                                         TipSjedista3,
                                         TipSjedista4,
                                         TipSjedista5);
            context.SaveChanges();


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

            context.DvoranaTipSjedista.AddRange(DvoranaTipSjedista1,
                                                DvoranaTipSjedista2,
                                                DvoranaTipSjedista3,
                                                DvoranaTipSjedista4,
                                                DvoranaTipSjedista5,
                                                DvoranaTipSjedista6,
                                                DvoranaTipSjedista7,
                                                DvoranaTipSjedista8,
                                                DvoranaTipSjedista9,
                                                DvoranaTipSjedista10,
                                                DvoranaTipSjedista11,
                                                DvoranaTipSjedista12,
                                                DvoranaTipSjedista13,
                                                DvoranaTipSjedista14,
                                                DvoranaTipSjedista15,
                                                DvoranaTipSjedista16,
                                                DvoranaTipSjedista17,
                                                DvoranaTipSjedista18,
                                                DvoranaTipSjedista19,
                                                DvoranaTipSjedista20,
                                                DvoranaTipSjedista21,
                                                DvoranaTipSjedista22,
                                                DvoranaTipSjedista23,
                                                DvoranaTipSjedista24,
                                                DvoranaTipSjedista25,
                                                DvoranaTipSjedista26,
                                                DvoranaTipSjedista27,
                                                DvoranaTipSjedista28,
                                                DvoranaTipSjedista29,
                                                DvoranaTipSjedista30,
                                                DvoranaTipSjedista31,
                                                DvoranaTipSjedista32,
                                                DvoranaTipSjedista33,
                                                DvoranaTipSjedista34,
                                                DvoranaTipSjedista35,
                                                DvoranaTipSjedista36,
                                                DvoranaTipSjedista37,
                                                DvoranaTipSjedista38,
                                                DvoranaTipSjedista39,
                                                DvoranaTipSjedista40);
            context.SaveChanges();


            Predstava Predstava1 = new Predstava { Naziv = "Waitress", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/Waitress.jpg" };
            Predstava Predstava2 = new Predstava { Naziv = "Wicked", Trajanje = "130min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/Wicked.jpg" };
            Predstava Predstava3 = new Predstava { Naziv = "Aint Too Proud", Trajanje = "115min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/AintTooProud.jpg" };
            Predstava Predstava4 = new Predstava { Naziv = "Be More Chill", Trajanje = "100min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/BeMoreChill.jpg" };
            Predstava Predstava5 = new Predstava { Naziv = "The Lion King", Trajanje = "145min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/TheLionKing.jpg" };
            Predstava Predstava6 = new Predstava { Naziv = "Pretty Woman", Trajanje = "120min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/PrettyWoman.jpg" };
            Predstava Predstava7 = new Predstava { Naziv = "Little Mermaid", Trajanje = "100min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/LittleMermaid.jpg" };
            Predstava Predstava8 = new Predstava { Naziv = "The Wizard of OZ", Trajanje = "100min", ReziserImePrezime = "ReziserIme ReziserPrezime", NazivIzvornogDjela = "Naziv Izvornog Djela", SlikaLink = "/images/Predstave/TheWizardOfOz.jpg" };

            Predstava1.Opis = Predstava2.Opis = Predstava3.Opis = Predstava4.Opis = Predstava5.Opis = Predstava6.Opis = Predstava7.Opis = Predstava8.Opis =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Sit amet aliquam id diam. Viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis. " +
                "Erat velit scelerisque in dictum non consectetur a. " +
                "Tempor nec feugiat nisl pretium fusce. Odio tempor orci dapibus ultrices in. " +
                "Sapien et ligula ullamcorper malesuada proin libero nunc consequat interdum. " +
                "Odio ut sem nulla pharetra. Vitae turpis massa sed elementum tempus egestas sed. " +
                "Malesuada proin libero nunc consequat interdum varius sit. " +
                "Sed euismod nisi porta lorem mollis aliquam ut porttitor leo. " +
                "At elementum eu facilisis sed odio morbi quis commodo. " +
                "Sem viverra aliquet eget sit amet tellus cras adipiscing enim. " +
                "Eget arcu dictum varius duis at consectetur. " +
                "Et ultrices neque ornare aenean euismod elementum nisi. " +
                "Vitae ultricies leo integer malesuada nunc vel risus commodo viverra. " +
                "Risus pretium quam vulputate dignissim suspendisse in est ante. Maecenas accumsan lacus vel facilisis volutpat est. " +
                "Non arcu risus quis varius quam quisque id. Nec feugiat nisl pretium fusce id velit ut.";

            context.Predstava.AddRange(Predstava1,
                                       Predstava2,
                                       Predstava3,
                                       Predstava4,
                                       Predstava5,
                                       Predstava6,
                                       Predstava7,
                                       Predstava8);
            context.SaveChanges();


            Zanr Zanr1 = new Zanr { Naziv = "Komedija" };
            Zanr Zanr2 = new Zanr { Naziv = "Tragedija" };
            Zanr Zanr3 = new Zanr { Naziv = "Fantazija" };
            Zanr Zanr4 = new Zanr { Naziv = "Mjuzikl" };
            Zanr Zanr5 = new Zanr { Naziv = "Opera" };
            Zanr Zanr6 = new Zanr { Naziv = "Satira" };
            Zanr Zanr7 = new Zanr { Naziv = "Psihodrama" };
            Zanr Zanr8 = new Zanr { Naziv = "Djeciji" };

            context.Zanr.AddRange(Zanr1,
                                  Zanr2,
                                  Zanr3,
                                  Zanr4,
                                  Zanr5,
                                  Zanr6,
                                  Zanr7,
                                  Zanr8);
            context.SaveChanges();


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

            context.Glumac.AddRange(Glumac1,
                                    Glumac2,
                                    Glumac3,
                                    Glumac4,
                                    Glumac5,
                                    Glumac6,
                                    Glumac7,
                                    Glumac8,
                                    Glumac9,
                                    Glumac10);
            context.SaveChanges();


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

            context.PredstavaZanr.AddRange(PredstavaZanr1,
                                           PredstavaZanr2,
                                           PredstavaZanr3,
                                           PredstavaZanr4,
                                           PredstavaZanr5,
                                           PredstavaZanr6,
                                           PredstavaZanr7,
                                           PredstavaZanr8,
                                           PredstavaZanr9,
                                           PredstavaZanr10,
                                           PredstavaZanr11,
                                           PredstavaZanr12,
                                           PredstavaZanr13,
                                           PredstavaZanr14,
                                           PredstavaZanr15,
                                           PredstavaZanr16,
                                           PredstavaZanr17,
                                           PredstavaZanr18,
                                           PredstavaZanr19,
                                           PredstavaZanr20);
            context.SaveChanges();


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

            context.Uloga.AddRange(Uloga1,
                                   Uloga2,
                                   Uloga3,
                                   Uloga4,
                                   Uloga5,
                                   Uloga6,
                                   Uloga7,
                                   Uloga8,
                                   Uloga9,
                                   Uloga10,
                                   Uloga11,
                                   Uloga12,
                                   Uloga13,
                                   Uloga14,
                                   Uloga15,
                                   Uloga16,
                                   Uloga17,
                                   Uloga18,
                                   Uloga19,
                                   Uloga20,
                                   Uloga21);
            context.SaveChanges();


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

            context.Termin.AddRange(Termin1,
                                    Termin2,
                                    Termin3,
                                    Termin4,
                                    Termin5,
                                    Termin6,
                                    Termin7,
                                    Termin8,
                                    Termin9,
                                    Termin10,
                                    Termin11,
                                    Termin12,
                                    Termin13,
                                    Termin14,
                                    Termin15,
                                    Termin16);
            context.SaveChanges();


            TipKorisnika TipKorisnika4 = new TipKorisnika { Naziv = "Gold", Cijena = 50, CijenaKartePopust = 0.5f, IduciTipKorisnika = null};
            TipKorisnika TipKorisnika3 = new TipKorisnika { Naziv = "Platinum", Cijena = 30, CijenaKartePopust = 0.3f, IduciTipKorisnika = TipKorisnika4 };
            TipKorisnika TipKorisnika2 = new TipKorisnika { Naziv = "Silver", Cijena = 10, CijenaKartePopust = 0.1f, IduciTipKorisnika = TipKorisnika3 };
            TipKorisnika TipKorisnika1 = new TipKorisnika { Naziv = "Standard", Cijena = 00, CijenaKartePopust = 0.0f, IduciTipKorisnika = TipKorisnika2, IsOsnovni = true };

            context.TipKorisnika.AddRange(TipKorisnika1,
                                          TipKorisnika2,
                                          TipKorisnika3,
                                          TipKorisnika4);
            context.SaveChanges();


            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac1", Email = "Kupac1@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac2", Email = "Kupac2@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac3", Email = "Kupac3@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikKupac4", Email = "Kupac4@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin1", Email = "Admin1@Email.com" }, "Password1!");
            await userManager.CreateAsync(new Korisnik { UserName = "KorisnikAdmin2", Email = "Admin2@Email.com" }, "Password1!");

            await roleManager.CreateAsync(new IdentityRole { Name = "Kupac", NormalizedName = "Kupac".ToUpper() });
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });

            Korisnik Korisnik1 = context.Korisnik.First(w => w.UserName == "KorisnikKupac1");
            Korisnik Korisnik2 = context.Korisnik.First(w => w.UserName == "KorisnikKupac2");
            Korisnik Korisnik3 = context.Korisnik.First(w => w.UserName == "KorisnikKupac3");
            Korisnik Korisnik4 = context.Korisnik.First(w => w.UserName == "KorisnikKupac4");
            Korisnik Korisnik5 = context.Korisnik.First(w => w.UserName == "KorisnikAdmin1");
            Korisnik Korisnik6 = context.Korisnik.First(w => w.UserName == "KorisnikAdmin2");

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

            context.Avatar.AddRange(Avatar1,
                                    Avatar2,
                                    Avatar3,
                                    Avatar4,
                                    Avatar5,
                                    Avatar6,
                                    Avatar7,
                                    Avatar8,
                                    Avatar9,
                                    Avatar10,
                                    Avatar11);
            context.SaveChanges();

            Kupac Kupac1 = new Kupac { Ime = "KupacIme1", Prezime = "KupacPrezime1", Grad = Grad1, TipKorisnika = TipKorisnika1, Username = Korisnik1.UserName, Korisnik = Korisnik1, Avatar=Avatar1};
            Kupac Kupac2 = new Kupac { Ime = "KupacIme2", Prezime = "KupacPrezime2", Grad = Grad1, TipKorisnika = TipKorisnika2, Username = Korisnik2.UserName, Korisnik = Korisnik1, Avatar=Avatar10};
            Kupac Kupac3 = new Kupac { Ime = "KupacIme3", Prezime = "KupacPrezime3", Grad = Grad2, TipKorisnika = TipKorisnika3, Username = Korisnik3.UserName, Korisnik = Korisnik1, Avatar=Avatar8};
            Kupac Kupac4 = new Kupac { Ime = "KupacIme4", Prezime = "KupacPrezime4", Grad = Grad2, TipKorisnika = TipKorisnika4, Username = Korisnik4.UserName, Korisnik = Korisnik1, Avatar=Avatar4};

            context.Kupac.AddRange(Kupac1,
                                   Kupac2,
                                   Kupac3,
                                   Kupac4);
            context.SaveChanges();

            Administrator Administrator1 = new Administrator { Korisnik = Korisnik5, Username = Korisnik5.UserName };
            Administrator Administrator2 = new Administrator { Korisnik = Korisnik6, Username = Korisnik6.UserName };

            context.Administrator.AddRange(Administrator1,
                                           Administrator2);
            context.SaveChanges();

            await userManager.CreateAsync(new Korisnik { UserName = "Adi", Email = "Adi@Gmail.com" }, "1");
            Korisnik KorisnikAdi = context.Korisnik.First(w => w.UserName == "Adi");
            await userManager.AddToRoleAsync(KorisnikAdi, "Kupac");
            Kupac KupacAdi = new Kupac { Ime = "Adi", Prezime = "Sose", Grad = Grad1, TipKorisnika = TipKorisnika3, Username = KorisnikAdi.UserName, Korisnik = KorisnikAdi, Avatar=Avatar5};
            context.Kupac.Add(KupacAdi);
            context.SaveChanges();


            Narudzba Narudzba1 = new Narudzba { Kupac = Kupac1, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };
            Narudzba Narudzba2 = new Narudzba { Kupac = Kupac1, Termin = Termin2, CijenaKarte = 15f, TipSjedista = TipSjedista4 };
            Narudzba Narudzba3 = new Narudzba { Kupac = Kupac2, Termin = Termin1, CijenaKarte = 10f, TipSjedista = TipSjedista1 };

            context.Narudzba.AddRange(Narudzba1,
                                      Narudzba2,
                                      Narudzba3);
            context.SaveChanges();


            Ocjena Ocjena1 = new Ocjena { Narudzba = Narudzba1, Vrijednost = 5, Review = "Review1" };
            Ocjena Ocjena2 = new Ocjena { Narudzba = Narudzba2, Vrijednost = 5, Review = "Review2" };
            Ocjena Ocjena3 = new Ocjena { Narudzba = Narudzba3, Vrijednost = 4, Review = "Review3" };

            context.Ocjena.AddRange(Ocjena1,
                                    Ocjena2,
                                    Ocjena3);
            context.SaveChanges();


            Obavijest Obavijest1 = new Obavijest { Naslov = "Obavijest1", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(9) };
            Obavijest Obavijest2 = new Obavijest { Naslov = "Obavijest2", Sadrzaj = "LoremIpsum", Administrator = Administrator1, DatumVrijeme = Danas.AddDays(-1).AddHours(8) };
            Obavijest Obavijest3 = new Obavijest { Naslov = "Obavijest3", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(7) };
            Obavijest Obavijest4 = new Obavijest { Naslov = "Obavijest4", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(6) };
            Obavijest Obavijest5 = new Obavijest { Naslov = "Obavijest5", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(5) };
            Obavijest Obavijest6 = new Obavijest { Naslov = "Obavijest6", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(4) };
            Obavijest Obavijest7 = new Obavijest { Naslov = "Obavijest7", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(3) };
            Obavijest Obavijest8 = new Obavijest { Naslov = "Obavijest8", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(2) };
            Obavijest Obavijest9 = new Obavijest { Naslov = "Obavijest9", Sadrzaj = "LoremIpsum", Administrator = Administrator2, DatumVrijeme = Danas.AddDays(-1).AddHours(1) };

            context.Obavijest.AddRange(Obavijest1,
                                       Obavijest2,
                                       Obavijest3,
                                       Obavijest4,
                                       Obavijest5,
                                       Obavijest6,
                                       Obavijest7,
                                       Obavijest8,
                                       Obavijest9);
            context.SaveChanges();


            Komentar Komentar1 = new Komentar { Sadrzaj = "Sadrzaj prvog komentara", Kupac = Kupac1, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(14) };
            Komentar Komentar2 = new Komentar { Sadrzaj = "Sadrzaj drugog komentara", Kupac = Kupac2, Obavijest = Obavijest1, DatumVrijeme = Danas.AddDays(-1).AddHours(15) };

            context.Komentar.AddRange(Komentar1, 
                                      Komentar2);
            
            context.Komentar.AddRange(Komentar1, Komentar2);
            context.SaveChanges();
        }
    }
}
