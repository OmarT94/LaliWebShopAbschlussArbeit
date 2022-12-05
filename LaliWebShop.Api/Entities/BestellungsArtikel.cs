namespace LaliWebShop.Api.Entities
{
    public class BestellungsArtikel
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }


        public Artikel Artikel { get; set; }
        public int ArtikelMenge { get; set; }


        public Bestellung Bestellung { get; set; }
        public int BestellungId { get; set; }
    }
}
