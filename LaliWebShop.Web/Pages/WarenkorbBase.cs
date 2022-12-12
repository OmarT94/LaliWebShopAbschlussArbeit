using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LaliWebShop.Web.Pages
{
    public class WarenkorbBase:ComponentBase
    {
        [Inject]
        public IJSRuntime js { get; set; }

        [Inject]
        public IWarenkorbService WarenkorbService { get; set; }
        public List<WarenkorbItemDto> WarenkorbItems { get; set; }
        public string ErrorMessage { get; set; }
        protected string GesamtePreis { get; set; }
        protected int GesamteMenge { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                WarenkorbItems=await WarenkorbService.GetItems(FestProgrammiert.KundeId);
                WarenkorbGaendert();
                
               
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
       
        private void SetGesamtePreis()
        {
            GesamtePreis = this.WarenkorbItems.Sum(a => a.Gesamtpreis).ToString("C");
        }

        private void SetGesamteMenge()
        {
            GesamteMenge = this.WarenkorbItems.Sum(a => a.ArtikelMenge);
        }

        private void RechneGesamteWarenkorb()
        {
            SetGesamteMenge();
            SetGesamtePreis();
        }
        private void UpdateItemGesamtPreis(WarenkorbItemDto warenkorbItemDto)
        {
            var item = GetWarenkorbItem(warenkorbItemDto.Id);
            if(item != null)
            {
                item.Gesamtpreis = warenkorbItemDto.ArtikelPreisSingleNetto * warenkorbItemDto.ArtikelMenge;
            }
        }
        protected async Task UpdateMenge_Input(int id)
        {
            await MachUpdateMengeButtonVisible(id, true);
        }
        protected async Task MachUpdateMengeButtonVisible(int id,bool visible)
        {
            await js.InvokeVoidAsync("MachUpdateMengeButtonVisible",id,true);
        }
        protected async Task DeleteWarenkorbItem_Button(int id)
        {
            var warenkorbItemDto = await WarenkorbService.DeleteItem(id);
            RemoveWarenkorbItem(id);
            WarenkorbGaendert();
        }
        protected async Task UpdateMengeWarenkorbItem_Click(int id, int menge)
        {
            try
            {
                if (menge > 0)
                {
                    var updateWarenkorbItemDto = new WarenkorbMengeUpdateDto
                    {
                        WarenkorbItemId = id,
                        WarenkorbItemMenge = menge
                    };
                    var returnupdateWarenkorbItemDto = await this.WarenkorbService.UpdateMenge(updateWarenkorbItemDto);

                    UpdateItemGesamtPreis(returnupdateWarenkorbItemDto);
                    WarenkorbGaendert();
                    await MachUpdateMengeButtonVisible(id, false);

                }

                else
                {
                    var item = this.WarenkorbItems.FirstOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        item.ArtikelMenge = 1;
                        item.Gesamtpreis = item.ArtikelPreisSingleNetto;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private WarenkorbItemDto GetWarenkorbItem(int id)
        {
            return WarenkorbItems.FirstOrDefault(i => i.Id == id);
        }
        private void RemoveWarenkorbItem(int id)
        {
            var warenkorbItemDto = GetWarenkorbItem(id);
            WarenkorbItems.Remove(warenkorbItemDto);
        }

        private void WarenkorbGaendert()
        {
            RechneGesamteWarenkorb();
            WarenkorbService.RaiseEventWarenkorbGaendert(GesamteMenge);
        }

    }
}
