using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTeatar.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Threading;

namespace eTeatar.Data
{
    public class MojContext : IdentityDbContext<Korisnik>
    {

        /// <summary>
        /// Konstruktor konteksta
        /// </summary>
        /// <param name="options">Parametri za kreiranje konteksta</param>
        public MojContext(DbContextOptions<MojContext> options) : base(options)
        {
        }

        #region Deklacarija entiteta

        public DbSet<Predstava> Predstava { get; set; }
        public DbSet<Glumac> Glumac { get; set; }
        public DbSet<Uloga> Uloga { get; set; }
        public DbSet<Zanr> Zanr { get; set; }
        public DbSet<PredstavaZanr> PredstavaZanr { get; set; } //Medjutabela
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<TipSjedista> TipSjedista { get; set; }
        public DbSet<Dvorana> Dvorana { get; set; }
        public DbSet<DvoranaTipSjedista> DvoranaTipSjedista { get; set; }
        public DbSet<Teatar> Teatar { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<TipKorisnika> TipKorisnika { get; set; }
        public DbSet<Komentar> Komentar { get; set; }
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<Avatar> Avatar { get; set; }

        #endregion

        /// <summary>
        /// Override funkcije kako bi omogucili koristenje Fluent API
        /// </summary>
        /// <param name="modelBuilder">Default parametar</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //Disable cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            #region Uloga

            //Definisanje brojnosti veze
            modelBuilder.Entity<Uloga>()
                .HasOne(ho => ho.Predstava)
                .WithMany(wm => wm.Uloge);

            //Definisanje brojnosti veze
            modelBuilder.Entity<Uloga>()
                .HasOne(ho => ho.Glumac)
                .WithMany(wm => wm.Uloge);

            #endregion

            #region PredstavaZanr

            //Definisanje primarnog kljuca
            modelBuilder.Entity<PredstavaZanr>()
           .HasKey(hk =>
           new
           {
               hk.PredstavaId,
               hk.ZanrId
           });

            //Definisanje stranog kljuca i brojnosti veze
            modelBuilder.Entity<PredstavaZanr>()
                .HasOne(ho => ho.Predstava)
                .WithMany(wm => wm.PredstavaZanr)
                .HasForeignKey(hfk => hfk.PredstavaId);

            //Definisanje stranog kljuca i brojnosti veze
            modelBuilder.Entity<PredstavaZanr>()
                .HasOne(ho => ho.Zanr)
                .WithMany(wm => wm.PredstavaZanr)
                .HasForeignKey(hfk => hfk.ZanrId);

            #endregion

            #region Ocjena

            //Definisanje brojnosti veze
            modelBuilder.Entity<Narudzba>()
                .HasOne(ho => ho.Ocjena)
                .WithOne(wo => wo.Narudzba)
                .HasForeignKey<Ocjena>(hfk => hfk.Id);

            #endregion

            #region Termin

            //Definisanje brojnosti veze
            modelBuilder.Entity<Termin>()
                .HasOne(ho => ho.Predstava)
                .WithMany(wm => wm.Termini);

            //Definisanje brojnosti veze
            modelBuilder.Entity<Termin>()
                .HasOne(ho => ho.Dvorana)
                .WithMany(wm => wm.Termini);

            #endregion

            #region Dvorana

            //Definisanje brojnosti veze
            modelBuilder.Entity<Dvorana>()
                .HasOne(ho => ho.Teatar)
                .WithMany(wm => wm.Dvorane);

            #endregion

            #region DvoranaTipSjedista

            //Definisanje primarnog kljuca
            modelBuilder.Entity<DvoranaTipSjedista>()
           .HasKey(hk =>
           new
           {
               hk.DvoranaId,
               hk.TipSjedistaId
           });

            //Definisanje stranog kljuca i brojnosti veze
            modelBuilder.Entity<DvoranaTipSjedista>()
                .HasOne(ho => ho.Dvorana)
                .WithMany(wm => wm.DvoranaTipSjedista)
                .HasForeignKey(hfk => hfk.DvoranaId);

            //Definisanje stranog kljuca i brojnosti veze
            modelBuilder.Entity<DvoranaTipSjedista>()
                .HasOne(ho => ho.TipSjedista)
                .WithMany(wm => wm.DvoranaTipSjedista)
                .HasForeignKey(hfk => hfk.TipSjedistaId);

            #endregion

            #region Teatar

            //Definisanje brojnosti veze
            modelBuilder.Entity<Teatar>()
                .HasOne(ho => ho.Grad)
                .WithMany(wm => wm.Teatari);

            #endregion

            #region Kupac

            //Definisanje brojnosti veze
            modelBuilder.Entity<Kupac>()
                .HasOne(ho => ho.Grad)
                .WithMany(wm => wm.Kupci);

            #endregion

            #region Komentar

            //Definisanje brojnosti veze
            modelBuilder.Entity<Komentar>()
                .HasOne(ho => ho.Kupac)
                .WithMany(wm => wm.Komentari);

            #endregion

            #region Obavijest

            //Definisanje brojnosti veze
            modelBuilder.Entity<Obavijest>()
                .HasOne(ho => ho.Administrator)
                .WithMany(wm => wm.Obavijesti);

            #endregion

            #region Narudzba

            //Definisanje brojnosti veze
            modelBuilder.Entity<Narudzba>()
                .HasOne(ho => ho.Kupac)
                .WithMany(wm => wm.Narudzbe);

            #endregion

            #region DodavanjeSoftDeletea

                modelBuilder.Entity<Dvorana>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<DvoranaTipSjedista>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Glumac>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Grad>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Komentar>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Korisnik>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Kupac>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Narudzba>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Obavijest>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Ocjena>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Predstava>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<PredstavaZanr>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Teatar>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Termin>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<TipKorisnika>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<TipSjedista>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Uloga>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Zanr>().HasQueryFilter(p => !p.IsDeleted);
                modelBuilder.Entity<Avatar>().HasQueryFilter(p => !p.IsDeleted);

            #endregion

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            //Todo: Whatafa

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is IIsDeleted entity)
                {
                    // Set the entity to unchanged (if we mark the whole entity as Modified, every field gets sent to Db as an update)
                    item.State = EntityState.Unchanged;
                    // Only update the IsDeleted flag - only this will get sent to the Db
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }

    }
}
