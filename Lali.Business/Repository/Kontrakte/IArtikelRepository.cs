using Lali.DataAccess.Entities;
using LaliWebShop.Models.Dtos;

namespace Lali.Business.Repository.Kontrakte
{
    public interface IArtikelRepository
    {
        public Task<IEnumerable<ArtikelDto>> GetItems();
        public Task <ArtikelDto> GetItem(int id);
        public Task<ArtikelDto> AddArtikel(ArtikelDto artikel);
        public Task<ArtikelDto> UpdateArtikel(ArtikelDto artikel);
        public Task <int> DeleteArtikel(int id);



    }
}
