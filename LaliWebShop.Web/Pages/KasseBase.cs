using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LaliWebShop.Web.Pages
{
    public class KasseBase:ComponentBase
    {

        [Inject]
        public IJSRuntime js { get; set; }

        protected IEnumerable<WarenkorbItemDto> warenkorbItemDtos { get; set; }
        protected int GesamteMenge { get; set; }
        protected string BezahlungsBezeichnung { get; set; }
        protected decimal BezahlungsHoehe { get; set; }

        [Inject]
        public IWarenkorbService warenkorbService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                warenkorbItemDtos = await warenkorbService.GetItems(FestProgrammiert.KundeId);
                if(warenkorbItemDtos != null)
                {
                    Guid bestellungGuid = Guid.NewGuid();
                    BezahlungsHoehe = warenkorbItemDtos.Sum(p => p.Gesamtpreis);
                    GesamteMenge = warenkorbItemDtos.Sum(a => a.ArtikelMenge);
                    BezahlungsBezeichnung = $"B_{FestProgrammiert.KundeId}_{bestellungGuid}";

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await js.InvokeVoidAsync("initPayPalButton");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
