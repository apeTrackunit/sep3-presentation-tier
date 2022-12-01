using System.Text;
using System.Text.Json;
using Model;
using Sep3PresentationTier.Shared;
using Services.Interfaces;

namespace Services.Implementations;

public class ReportService : IReportService
{
    private readonly HttpClient client;
    private readonly TokenService tokenService;

    public ReportService(HttpClient client, TokenService tokenService)
    {
        this.client = client;
        this.tokenService = tokenService;
    }

    public async Task<ICollection<Report>> GetAsync()
    {
        await tokenService.AttachToken(client);
        
        HttpResponseMessage response = await client.GetAsync("/reports");
        string result = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);
        
        ICollection<Report> reports = JsonSerializer.Deserialize<ICollection<Report>>(result,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true})!;
        return reports;
    }

    public async Task<bool> CreateAsync(Report report)
    {
        await tokenService.AttachToken(client);
        
        string userAsJson = JsonSerializer.Serialize(report);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8910/report", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        
        return true;
    }
}