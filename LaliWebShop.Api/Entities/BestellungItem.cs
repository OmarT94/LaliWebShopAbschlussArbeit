using System.ComponentModel.DataAnnotations.Schema;

namespace LaliWebShop.Api.Entities
{
    public class BestellungItem
    {
        public string ArtikelNummer { get; set; }
        public string ArtikelName { get; set; }
        public string ArtikelBezeichnung { get; set; }
        public int ArtikelMenge { get; set; }
        public string ArtikelImage { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal ArtikelPreisSingleNetto { get; set; }
        public decimal ArtikelPreisGesamtNetto { get; set; }
        public decimal Mwst { get; set; } // Mehrwertsteuer
        public decimal GesamtPreis { get; set; } // ArtikelPreisGesamtNetto + Mwst
        public decimal GetGesamtPreis()
        {
            return GesamtPreis=ArtikelPreisGesamtNetto + Mwst;
        }
       
    }
}
