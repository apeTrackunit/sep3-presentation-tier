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


    public async Task<ICollection<EventOverviewDto>> GetAsync(string filter)
    {
        await tokenService.AttachToken(client);

        HttpResponseMessage response = await client.GetAsync($"/events/?filter={filter}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(result);

        ICollection<EventOverviewDto> events = JsonSerializer.Deserialize<ICollection<EventOverviewDto>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        })!;
        return events;
    }

    public async Task<bool> CreateAsync(Event cleaningEvent)
    {
        await tokenService.AttachToken(client);

        CreateEventDto createEventDto = new CreateEventDto
        {
            date = cleaningEvent.Date,
            time = cleaningEvent.Time,
            description = cleaningEvent.Description,
            reportId = cleaningEvent.Report.Id
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

    public async Task<bool> ApproveEvent(string eventId, bool approved)
    {
        string updateReportAsJson = JsonSerializer.Serialize(approved);
        
        StringContent content = new(updateReportAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PatchAsync($"http://localhost:8910/events/{eventId}", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        return true;
    }

    public async Task<Event> GetEvent(string id)
    {
        await tokenService.AttachToken(client);
        
        HttpResponseMessage response = await client.GetAsync($"/events/{id}");
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);
        
        Event ev = JsonSerializer.Deserialize<Event>(result,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true})!;
        
        return ev;
    }

    public async Task<bool> AttendEvent(string eventId)
    {
        await tokenService.AttachToken(client);

        string eventIdAsJson = JsonSerializer.Serialize(eventId);
        StringContent content = new StringContent(eventIdAsJson, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync($"/events/attend?eventId={eventId}", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception(responseContent);

        return true;
    }
}