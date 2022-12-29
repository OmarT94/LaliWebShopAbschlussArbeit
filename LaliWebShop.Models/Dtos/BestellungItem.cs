using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public class BestellungItemDto
    {

        public int Id { get; set; }
        [Required]
        public int BestellungId { get; set; }
        [Required]
        public int ArtikelId { get; set; }
        
        public  ArtikelDto Artikel { get; set; }
        [Required]
        public int Menge { get; set; }
        [Required]
        public decimal ArtikelPreisSingleNetto { get; set; }
        [Required]
        public string ArtikelName { get; set; }




    }
}
