using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lali.DataAccess.Entities
{
    public class BestellungItem
    {
        //public string ArtikelNummer { get; set; }
        //public string ArtikelName { get; set; }
        //public string ArtikelBezeichnung { get; set; }
        //public int ArtikelMenge { get; set; }
        //public string ArtikelImage { get; set; }

        //[Column(TypeName = "decimal(10, 2)")]
        //public decimal ArtikelPreisSingleNetto { get; set; }
        //public decimal ArtikelPreisGesamtNetto { get; set; }
        //public decimal Mwst { get; set; } // Mehrwertsteuer
        //public decimal GesamtPreis { get; set; } // ArtikelPreisGesamtNetto + Mwst
        //public decimal GetGesamtPreis()
        //{
        //    return GesamtPreis = ArtikelPreisGesamtNetto + Mwst;
        //}

        public int Id { get; set; }
        [Required]
        public int BestellungId { get; set; }
        [Required]
        public int ArtikelId { get; set; }
        [ForeignKey("ArtikelId")]
        [NotMapped]
        public virtual Artikel Artikel { get; set; }
        [Required]
        public int Menge { get; set; }
        [Required]
        public decimal ArtikelPreisSingleNetto { get; set; }
        [Required]
        public string ArtikelName { get; set; }




    }
}
