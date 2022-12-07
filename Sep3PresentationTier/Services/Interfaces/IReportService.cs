using Model;

namespace Services.Interfaces;

public interface IReportService
{
    Task<ICollection<Report>> GetReportsAsync(bool approved);
    Task<Report> GetReportAsync(string id);
    Task<bool> CreateAsync(Report report);
    Task<bool> ApproveAsync(string reportId, string status);
}