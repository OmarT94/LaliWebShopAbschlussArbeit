using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.ViewModels;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IWarenkorbService
    {
        //Task<List<WarenkorbItemDto>> GetItems(int kundeId);
        Task AddItem(WarenkorbSicht warenkorbSicht);
        Task DeleteItem(WarenkorbSicht warenkorbSicht);
        //Task<WarenkorbItemDto> UpdateMenge(WarenkorbMengeUpdateDto warenkorbMengeUpdateDto);

        event Action WarenkorbGaendert;
        //void RaiseEventWarenkorbGaendert(int gesamteMenge);
    }
}
