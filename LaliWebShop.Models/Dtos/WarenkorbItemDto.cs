using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class WarenkorbItemDto
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
        public decimal Mwst { get; set; } 
        public decimal Gesamtpreis { get; set; }
        public string? KategorieName { get; set; }

    }
}
