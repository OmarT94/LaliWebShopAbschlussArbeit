namespace LaliWebShop.Api.Entities
{
    public class Bestellung
    {

        public int Id { get; set; }
        public int BestellNummer { get; set; }
        public int KundenId { get; set; }
        public DateTime BestelltAm { get; set; }
        public decimal SummeNetto { get; set; }
        public decimal MwSt { get; set; }
        public decimal SummeBrutto { get; set; }
        public ICollection<BestellungsArtikel>? BestellungsArtikel { get; set; }
        // List<BestellungItem> Artikel { get; set; }

        //class BestellungItem
        //{
        //    public string ArtikelNummer { get; set; }
        //    public string ArtikelName { get; set; }
        //    public string ArtikelBezeichnung { get; set; }
        //    public int ArtikelMenge { get; set; }
        //    public string ArtikelImage { get; set; }
        //    public decimal ArtikelPreisSingleNetto { get; set; }
        //    public decimal ArtikelPreisGesamtNetto { get; set; }
        //    public decimal Mwst { get; set; } // Mehrwertsteuer
        //    public decimal Gesamtpreis { get; set; } // ArtikelPreisGesamtNetto + Mwst
        //}


    }
}
