using LaliWebShop.Api.Entities;
using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Api.Repository.Kontrakte
{
    public interface IWarenkorbRepository
    {
        Task<WarenkorbItem> AddItem(WarenkorbItemToAddDto warenkrobItemToAddDto);
        Task<WarenkorbItem> UpdateMenge(int id,WarenkorbMengeUpdateDto warenkorbMengeUpdateDto);
        Task <WarenkorbItem> DeleteItem(int id);
        Task<WarenkorbItem> GetItem(int id);
        Task<IEnumerable<WarenkorbItem>> GetAllItems(int kundeId);

    }
}
