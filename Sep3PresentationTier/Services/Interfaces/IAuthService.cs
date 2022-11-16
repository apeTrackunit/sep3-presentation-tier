using Model;
using Model.DTOs;

namespace Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterUserDto user);

    Task LoginAsync(UserLoginDto user);
}