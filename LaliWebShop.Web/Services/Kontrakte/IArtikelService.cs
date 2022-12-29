using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IArtikelService
    {
        Task<IEnumerable<ArtikelDto>> GetItems();
        Task<ArtikelDto> GetItem(int artikelId);
       
    }
}
