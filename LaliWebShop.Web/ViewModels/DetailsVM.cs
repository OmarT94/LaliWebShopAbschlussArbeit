using System.ComponentModel.DataAnnotations;
using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            artikelPreis = new();
            Count = 1;
        }

        [Range(1, int.MaxValue, ErrorMessage = "Bite wählen Sie eine Nummer großer als 0")]
        public int Count { get; set; }
        public ArtikelDto artikelPreis { get; set; }
    }
}
