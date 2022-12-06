using Model;

namespace Services.Interfaces;

public interface IReportService
{
    Task<ICollection<Report>> GetAsync(bool approved);
    Task<bool> CreateAsync(Report report);
    Task<bool> ApproveAsync(string reportId, string status);
}