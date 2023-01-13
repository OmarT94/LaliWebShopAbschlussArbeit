using Blazored.LocalStorage;
using Lali.Common;
using LaliWebShop.Models.Dtos;
using LaliWebShop.Web.Services.Kontrakte;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace LaliWebShop.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<SignInResponseDto> Login(SignInRequestDto signInRequest)
        {
            var content = JsonConvert.SerializeObject(signInRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignInResponseDto>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorage.SetItemAsync(SD.Local_BenutzerDetails, result.BenutzerDto);
                ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);
                _client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("bearer", result.Token);
                return new SignInResponseDto() { IsAuthErfolgreich = true };
            }
            else
            {
                return result;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(SD.Local_Token);
            await _localStorage.RemoveItemAsync(SD.Local_BenutzerDetails);

            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();

            _client.DefaultRequestHeaders.Authorization= null;
        }

        public async Task<SignUpResponseDto> RegisterUser(SignUpRequestDto signUpRequest)
        {
            var content = JsonConvert.SerializeObject(signUpRequest);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signup", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SignUpResponseDto>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                return new SignUpResponseDto { IstRegisterationErfolgreich = true };
            }
            else
            {
                return new SignUpResponseDto { IstRegisterationErfolgreich = false, Errors=result.Errors };
            }
        }
    }
}
