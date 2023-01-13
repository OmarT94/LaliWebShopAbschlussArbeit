using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components;


namespace LaliWebShop.Web.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authSerivce { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authSerivce.Logout();
            _navigationManager.NavigateTo("/");
        }
    }
}
