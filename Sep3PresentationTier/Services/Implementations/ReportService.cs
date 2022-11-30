using System.Text.Json;
using Model;
using Services.Interfaces;

namespace Services.Implementations;

public class ReportService : IReportService
{
    private readonly HttpClient client;

    public ReportService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ICollection<Report>> GetAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/reports");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);
        
        ICollection<Report> reports = JsonSerializer.Deserialize<ICollection<Report>>(result,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true})!;
        return reports;
    }
}