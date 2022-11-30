using System.Text;
using System.Text.Json;
using Model.DTOs;
using Services.Interfaces;

namespace Services.Implementations;

public class AuthService : IAuthService
{
    private readonly HttpClient client;

    public AuthService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<string> RegisterAsync(RegisterUserDto user)
    {
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8910/register", content);

        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
            throw new Exception(responseContent);

        return responseContent;
    }
}