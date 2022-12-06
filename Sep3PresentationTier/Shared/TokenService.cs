using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace Sep3PresentationTier.Shared;

public class TokenService
{
    private readonly ILocalStorageService localStorageService;
    
    public TokenService(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public async Task AttachToken(HttpClient client)
    {
        var token = await localStorageService.GetItemAsync<string>("JWT");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}