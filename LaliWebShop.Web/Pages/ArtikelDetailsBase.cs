using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components;

namespace LaliWebShop.Web.Pages
{
    public class ArtikelDetailsBase:ComponentBase
    {
        [Parameter] 
        public int Id { get; set; }

        [Inject]
        public IArtikelService ArtikelService { get; set; }

        [Inject]
        public IWarenkorbService WarenkorbService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ArtikelDto artikel { get; set; }
        public string ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                artikel = await ArtikelService.GetItem(Id);
            }
            catch (Exception e)
            {

               ErrorMessage = e.Message;
            }
        }

        protected async Task AddToWarenkorb_Button(WarenkorbItemToAddDto warenkorbItemToAddDto)
        {
            try
            {
                var warenkorbItemDto= await WarenkorbService.AddItem(warenkorbItemToAddDto);
                NavigationManager.NavigateTo("/Warenkorb");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
