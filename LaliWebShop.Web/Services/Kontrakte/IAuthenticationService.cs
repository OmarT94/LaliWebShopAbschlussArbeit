using LaliWebShop.Models.Dtos;


namespace LaliWebShop.Web.Services.Kontrakte
{
    public interface IAuthenticationService
    {
        Task<SignUpResponseDto> RegisterUser(SignUpRequestDto signUpRequestDTO);
        Task<SignInResponseDto> Login(SignInRequestDto signInRequestDTO);
        Task Logout();
    }
}
