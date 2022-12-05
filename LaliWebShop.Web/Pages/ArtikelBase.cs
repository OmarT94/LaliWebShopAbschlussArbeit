using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components;

namespace LaliWebShop.Web.Pages
{
    public class ArtikelBase : ComponentBase
    {
        [Inject]
        public IArtikelService ArtikelService {get; set;}

        [Inject]
        public IWarenkorbService WarenkorbService { get; set; }

        public IEnumerable<ArtikelDto> Artikels { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Artikels = await ArtikelService.GetItems();
                var warenkorbItems = await WarenkorbService.GetItems(FestProgrammiert.KundeId);
                var gesamteMenge = warenkorbItems.Sum(i => i.ArtikelMenge);

                WarenkorbService.RaiseEventWarenkorbGaendert(gesamteMenge);

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
           
        }

        protected IOrderedEnumerable<IGrouping<int,ArtikelDto>> GetGroupArtikelByKategorie()
        {
            return from artikel in Artikels
                   group artikel by artikel.KategorieId into artikelByKatrgorieGroup
                   orderby artikelByKatrgorieGroup.Key
                   select artikelByKatrgorieGroup;
        }

        protected string GetKategorieName (IGrouping<int,ArtikelDto> groupeArtikelDto)
        {
            return groupeArtikelDto.FirstOrDefault(ag => ag.KategorieId == groupeArtikelDto.Key).KategorieName;
        }

    }
}
