using Model.DTOs;

namespace Services.Interfaces;

public interface IAuthService
{
    Task<String> RegisterAsync(RegisterUserDto user);
}