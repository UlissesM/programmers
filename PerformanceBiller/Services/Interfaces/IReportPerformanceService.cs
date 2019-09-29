using PerformanceBiller.Models;

namespace PerformanceBiller.Services.Interfaces
{
    public interface IReportPerformanceService
    {
        string CreateReport(ReportModel reportModel);
    }
}
