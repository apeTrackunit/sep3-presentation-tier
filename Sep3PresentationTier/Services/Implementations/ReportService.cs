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
}