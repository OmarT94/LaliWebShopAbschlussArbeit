using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaliWebShop.Models.Dtos
{
    public  class ArtikelDto
    {
        
        public int Id { get; set; }
        [Required]
        public string? Artikelnummer { get; set; }
        [Required]
        public string? Name { get; set; }
        
        public string? Bezeichnung { get; set; }
        
        public string? ImageURL { get; set; }
       
        public decimal PreisSingleNetto { get; set; }
       
        public int Menge { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Bitte eine Kategorie wählen")]
        public int KategorieId { get; set; }
        public KategorieDto Kategorie { get; set; }
       

        public string GetPreisAsString()
        {
            return string.Format($"{PreisSingleNetto}€");
        }


    }
}
