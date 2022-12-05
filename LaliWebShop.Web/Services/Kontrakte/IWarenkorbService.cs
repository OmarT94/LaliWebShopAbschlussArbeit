using LaliWebShop.Models.Dtos;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IWarenkorbService
    {
        Task<List<WarenkorbItemDto>> GetItems(int kundeId);
        Task<WarenkorbItemDto>AddItem(WarenkorbItemToAddDto warenkorbItemToAddDto);
        Task<WarenkorbItemDto> DeleteItem(int id);
        Task<WarenkorbItemDto> UpdateMenge(WarenkorbMengeUpdateDto warenkorbMengeUpdateDto);

        event Action<int> WarenkorbGaendert;
        void RaiseEventWarenkorbGaendert(int gesamteMenge);
    }
}
