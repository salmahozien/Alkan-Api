
using flutterApi.DTOs.Register;
using flutterApi.DTOs.User;
using login.DTOs;

namespace flutterApi.Interfaces
{
    public interface IAuthService
       
    {
        Task<AuthRegisterDto> RegisterAsync(RegisterDto model);
       
        Task<AuthRegisterDto> Login(LoginDto model);
        Task<string> AddRoleAsync(AddRoleModelDto roleName);
        Task<AuthRegisterDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    
    Task Logout();

    }
}
