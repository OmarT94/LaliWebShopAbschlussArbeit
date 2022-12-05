namespace LaliWebShop.Api.Entities
{
    public class Warenkorb
    {

        public int Id { get; set; }
        public int KundenId { get; set; }
        public int BestellungId { get; set; }

        //List<Warenkorbitem> Artikel { get; set; }

        //class Warenkorbitem
        //{
        //    public string ArtikelName { get; set; }
        //    public string ArtikelBezeichnung { get; set; }
        //    public string ArtikelNummer { get; set; }
        //    public int ArtikelMenge { get; set; }
        //    public string ArtikelImage { get; set; }
        //    public decimal ArtikelPreisSingleNetto { get; set; }
        //    public decimal ArtikelPreisGesamtNetto { get; set; }
        //    public decimal Mwst { get; set; } // Mehrwertsteuer
        //    public decimal Gesamtpreis { get; set; } // ArtikelPreisGesamtNetto + Mwst
        //}
        
    }
}
