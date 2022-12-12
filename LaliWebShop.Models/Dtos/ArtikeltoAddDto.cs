using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class ArtikeltoAddDto
    {
        public int Id { get; set; }
        public string? Artikelnummer { get; set; }
        public string Name { get; set; }
        public string Bezeichnung { get; set; }
        public string? ImageURL { get; set; }
        public decimal PreisSingleNetto { get; set; }
        public int Menge { get; set; }
        public int ?KategorieId { get; set; }
        public string KategorieName { get; set; }
        public int? BestellungId { get; set; }
    }
}
