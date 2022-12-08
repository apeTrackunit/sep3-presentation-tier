namespace Services.Implementations;

using System.Text;
using System.Text.Json;
using Interfaces;
using Model;
using Model.DTOs;
using Sep3PresentationTier.Shared;

public class EventService:IEventService
{
    private readonly HttpClient client;
    private readonly TokenService tokenService;

    public EventService(HttpClient client, TokenService tokenService)
    {
        this.client = client;
        this.tokenService = tokenService;
    }

    
    public async Task<bool> CreateAsync(Event cleaningEvent)
    {
        await tokenService.AttachToken(client);

        CreateEventDto createEventDto = new CreateEventDto
        {
            Date = cleaningEvent.Date,
            Time = cleaningEvent.Time,
            Description = cleaningEvent.Description,
            ReportId = cleaningEvent.ReportRef.Id
        };

        string eventAsJson = JsonSerializer.Serialize(createEventDto);
        StringContent content = new(eventAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8910/events", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        return true;

    }
}