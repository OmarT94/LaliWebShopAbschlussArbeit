namespace LaliWebShop.Api.Entities
{
    public class Artikel
    {
       public int Id { get; set; }
       public string ?Artikelnummer { get; set; }
       public string ?Name { get; set; }
       public string ?Bezeichnung { get; set; }
       public string ?ImageURL { get; set; }
       public decimal PreisSingleNetto { get; set; }
       public int Menge { get; set; }
       public int KategorieId { get; set; }
       public string ?KategorieName { get; set; }
        public int? BestellungId { get; set; }

        public string GetPreisAsString()
        {
            return string.Format($"{PreisSingleNetto}€");
        }

        public ICollection<BestellungsArtikel>? BestellungsArtikel { get; set; }





        //class ArtikelKategorie
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    //public string Artikelnummer { get; set; }
        //    //public string Bezeichnung { get; set; }
        //    //public string ImageUrl { get; set; }
        //    //public decimal PreisSingleNetto { get; set; }

        //    List<Artikel> Artikel { get; set; }
        //}

    }
}
