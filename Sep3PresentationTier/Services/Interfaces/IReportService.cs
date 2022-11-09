using Model;

namespace Services.Interfaces;

public interface IReportService
{
    Task<ICollection<Report>> GetAsync();
}