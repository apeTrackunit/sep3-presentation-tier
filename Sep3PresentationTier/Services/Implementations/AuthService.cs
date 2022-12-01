using System.Text;
using System.Security.Claims;
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
    
    public async Task<string> LoginAsync(LoginUserDto user)
    {
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8910/login", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        string token = responseContent;
        
        return token;
    }
    
    //JWT interaction
    // Below methods taken from https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/blob/master/demos/MissionControl/MissionControl.Client/Util/ServiceExtensions.cs
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal(String jwt)
    {
        if (string.IsNullOrEmpty(jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(jwt);
    
        ClaimsIdentity identity = new(claims, jwt);

        ClaimsPrincipal principal = new(identity);
        return principal;
    }
}