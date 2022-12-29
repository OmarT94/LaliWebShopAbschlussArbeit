using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.ViewModels
{
    public class WarenkorbSicht
    {
        public int ArtikelId { get; set; }
        public int Count { get; set; }
        public ArtikelDto Artikel { get; set; }


    }
}
