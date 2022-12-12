using LaliWebShop.Api.Entities;
using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Api.Repository.Kontrakte
{
    public interface IArtikelRepository
    {
        Task<IEnumerable<Artikel>> GetItems();
        Task<IEnumerable<Kategorie>> GetKategorien();
        Task <Artikel> GetItem(int id);
        Task <Kategorie> GetKategorie(int id);
        Task<ArtikeltoAddDto> AddArtikel(ArtikeltoAddDto artikel);
        Task<ArtikeltoAddDto> UpdateArtikel(ArtikeltoAddDto artikel);
        Task<Artikel> DeleteArtikel(int id);



    }
}
