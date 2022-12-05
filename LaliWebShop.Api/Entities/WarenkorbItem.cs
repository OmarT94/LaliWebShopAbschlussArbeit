namespace LaliWebShop.Api.Entities
{
    public class WarenkorbItem
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int WarenkorbId { get; set; }
        public string ?ArtikelName { get; set; }
        public string ?ArtikelBezeichnung { get; set; }
        public string ?ArtikelNummer { get; set; }
        public int ArtikelMenge { get; set; }
        public string ?ArtikelImage { get; set; }
        public decimal ArtikelPreisSingleNetto { get; set; }
        public decimal ArtikelPreisGesamtNetto { get; set; }
        public decimal Mwst { get; set; } // Mehrwertsteuer
        public decimal Gesamtpreis { get; set; } // ArtikelPreisGesamtNetto + Mwst
        public string? KategorielName { get; set; }
    }
}
