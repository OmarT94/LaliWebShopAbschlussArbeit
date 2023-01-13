using Lali.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.Data
{
    public class ShopDbContext: IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 1,
                Artikelnummer = "K1",
                Name = "TestKleidung",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/Kleidung/Kleider.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 1,
                //KategorieName = "Kleidung"



            });

            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 2,
                Artikelnummer = "H1",
                Name = "HaushaltgeräteTest",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/Haushaltgeräte/HaushaltGerät.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 2,
                //KategorieName = "Haushaltgeräte"



            });
            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 3,
                Artikelnummer = "E1",
                Name = " ElektronikgeräteTest",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/Elektronikgeräte/ElekGerät.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 3,
                //KategorieName = "Elektronikgeräte"



            });
            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 4,
                Artikelnummer = "C1",
                Name = "ComputerTest",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/Computer/Computer.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 4,
                //KategorieName = "Computer"



            });
            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 5,
                Artikelnummer = "M1",
                Name = "MobiletelefoneTest",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/Mobiletelefone/Mobile.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 5,
                //KategorieName = "Mobiletelefone"



            });
            modelBuilder.Entity<Artikel>().HasData(new Artikel
            {



                Id = 6,
                Artikelnummer = "T1",
                Name = "TestKategorieTest",
                Bezeichnung = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImageURL = "/ArtikelImages/TestKategorie/Test.png",
                PreisSingleNetto = 100,
                Menge = 100,
                KategorieId = 6,
                //KategorieName = "TestKategorie"



            });

            //ArtikelKategorie
            //Add Artikel Kategorie
            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 1,
                Name = "Kleidung",
                //IconCSS = "fas fa-spa"
            });
            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 2,
                Name = "Haushaltgeräte",
                //IconCSS = "fas fa-couch"

            });
            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 3,
                Name = "Elektronikgeräte",
                //IconCSS = "fas fa-headphones"
            });
            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 4,
                Name = "Computer",
                //IconCSS = "fas fa-shoe-prints"
            });

            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 5,
                Name = "Mobiletelefone",
                //IconCSS = "fas fa-shoe-prints"
            });
            modelBuilder.Entity<Kategorie>().HasData(new Kategorie
            {
                Id = 6,
                Name = "TestKategorie",
                //IconCSS = "fas fa-shoe-prints"
            });
            modelBuilder.Entity<Warenkorb>().HasData(new Warenkorb
            {
                Id = 1,
                KundenId = 1

            });
            //modelBuilder.Entity<Kunde>().HasData(new Kunde
            //{
            //    //Id = 1,
            //    //Anrede = "Herr",
            //    //Name = "testname",
            //    //Vorname = "TestVorname",
            //    //Email = "TestWmail@test.com",
            //    //Ort = "TestOrt",
            //    //Land = "Testland",
            //    //Hausnummer = 5,
            //    //Plz = 52551,
            //    //Strasse = "testStraße",
            //    //KundenNummer = 518



            //});

            //modelBuilder.Entity<BestellungsArtikel>().HasKey(s => new { s.ArtikelId, s.BestellungId });

            //modelBuilder.Entity<BestellungsArtikel>()
            //.HasOne<Bestellung>(sc => sc.Bestellung)
            //.WithMany(s => s.BestellungsArtikel)
            //.HasForeignKey(sc => sc.BestellungId);


            //modelBuilder.Entity<BestellungsArtikel>()
            //.HasOne<Artikel>(sc => sc.Artikel)
            //.WithMany(s => s.BestellungsArtikel)
            //.HasForeignKey(sc => sc.ArtikelId);

        }

        //public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
        public DbSet<Warenkorb> Warenkorb { get; set; }
        public DbSet<WarenkorbItem> WarenkorbItem { get; set; }
        public DbSet<Bestellung> Bestellung { get; set; }
        public DbSet<BestellungItem> BestellungItems { get; set; }
        public DbSet<ApplicationBenutzer> ApplicationBenutzers { get; set; }


    }
}
