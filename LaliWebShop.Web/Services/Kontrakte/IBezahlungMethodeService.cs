using LaliWebShop.Models;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.ViewModels;

namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IBezahlungMethodeService
    {

        public Task<SuccessModelDto> Checkout(BezahlungDto bezahlungDtoModel);
     
    }
}
