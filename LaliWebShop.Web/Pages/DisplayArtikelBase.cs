using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace LaliWebShop.Web.Pages
{
    public class DisplayArtikelBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ArtikelDto> Artikels { get; set; }
    }
}
