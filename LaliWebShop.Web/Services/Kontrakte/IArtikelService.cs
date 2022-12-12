using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IArtikelService
    {
        Task<IEnumerable<ArtikelDto>> GetItems();
        Task<ArtikelDto> GetItem(int id);
        //Task<ArtikeltoAddDto> AddArtikel(ArtikeltoAddDto artikel);
        //Task<ArtikeltoAddDto> UpdateArtikel(ArtikeltoAddDto artikel);
        //Task<ArtikelDto> DeleteArtikel(int id);
    }
}
