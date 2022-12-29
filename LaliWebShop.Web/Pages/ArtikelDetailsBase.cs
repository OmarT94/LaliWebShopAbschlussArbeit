using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Helper;
using LaliWebShop.Web.Services.Kontrakte;
using LaliWebShop.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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
        [Inject]
        public IJSRuntime js { get; set; }

        public DetailsVM DetailsVM { get; set; } = new();

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

        protected async Task AddToWarenkorb_Button()
        {
            try
            {
                WarenkorbSicht warenkorb= new()
                {
                    Count = DetailsVM.Count,
                    ArtikelId = artikel.Id
                };
                await WarenkorbService.AddItem(warenkorb);
                NavigationManager.NavigateTo("/");
                await js.ToastrSuccess("Der Artikel wurde erfolgreich in den Warenkorb hinzugefügt ");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
