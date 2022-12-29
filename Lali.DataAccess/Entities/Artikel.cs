using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.Entities
{
    public class Artikel
    {
        [Key]
        public int Id { get; set; }
        public string? Artikelnummer { get; set; }
        public string? Name { get; set; }
        public string? Bezeichnung { get; set; }
        public string? ImageURL { get; set; }
        public decimal PreisSingleNetto { get; set; }
        public int Menge { get; set; }
        public int KategorieId { get; set; }
        [ForeignKey("KategorieId")]
        public Kategorie Kategorie { get; set; }

        public string GetPreisAsString()
        {
            return string.Format($"{PreisSingleNetto}€");
        }

        //public ICollection<BestellungsArtikel>? BestellungsArtikel { get; set; }

    }
}
