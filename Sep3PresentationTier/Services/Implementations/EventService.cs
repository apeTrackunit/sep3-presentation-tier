using System.Text.Json;
using Model;
using Sep3PresentationTier.Shared;
using Services.Interfaces;

namespace Services.Implementations;

public class EventService : IEventService
{

    private HttpClient client;
    private TokenService tokenService;

    public EventService(HttpClient client, TokenService tokenService)
    {
        this.client = client;
        this.tokenService = tokenService;
    }

    public async Task<ICollection<Event>> GetAsync()
    {
        await tokenService.AttachToken(client);

        HttpResponseMessage response = await client.GetAsync("/events");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(result);

        ICollection<Event> events = JsonSerializer.Deserialize<ICollection<Event>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        })!;
        return events;
    }
}