using System.Text;
using System.Text.Json;
using Model;
using Model.DTOs;
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

    public async Task<ICollection<Report>> GetAsync(bool approved)
    {
        await tokenService.AttachToken(client);
        

        HttpResponseMessage response = await client.GetAsync($"/reports?approved={approved}");
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

        CreateReportDto createReportDto = new CreateReportDto()
        {
            date = report.Date,
            time = report.Time,
            description = report.Description,
            location = report.Location,
            proof = report.Proof,
            status = report.Status
        };
        
        string reportAsJson = JsonSerializer.Serialize(createReportDto);
        StringContent content = new(reportAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("http://localhost:8910/reports", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        
        return true;
    }

    public async Task<bool> ApproveAsync(string reportId, string status)
    {
        UpdateReportDto updateReportDto = new UpdateReportDto(status);
        string updateReportAsJson = JsonSerializer.Serialize(updateReportDto);
        
        StringContent content = new(updateReportAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PatchAsync($"http://localhost:8910/reports/{reportId}", content);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        return true;
    }
}