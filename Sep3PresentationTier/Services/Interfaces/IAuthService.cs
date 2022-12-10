using Model.DTOs;
using Model;

namespace Services.Interfaces;

public interface IAuthService
{
    Task<String> RegisterAsync(RegisterUserDto user);
    Task AddAdminAsync(RegisterUserDto user);

    Task<String> LoginAsync(LoginUserDto user);
}