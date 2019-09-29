using PerformanceBiller.Models;
using PerformanceBiller.Models.Builder;
using PerformanceBiller.Models.Category;
using PerformanceBiller.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceBiller
{
    public class Statement
    {
        private readonly IReportPerformanceService _reportPerformanceService;

        public Statement(IReportPerformanceService reportPerformanceService)
        {
            _reportPerformanceService = reportPerformanceService;
        }

        public string PrintReport(InvoiceModel invoice, string cultureFormat)
        {
            var rules = GetPerformancesCategoryRule(invoice);

            var reportModel = ReportModel.Create(invoice.Customer, rules, cultureFormat);

            return _reportPerformanceService.CreateReport(reportModel);
        }

        public string PrintReport(InvoiceModel invoice)
        {
            var rules = GetPerformancesCategoryRule(invoice);

            var reportModel = ReportModel.Create(invoice.Customer, rules);

            return _reportPerformanceService.CreateReport(reportModel);
        }

        private static IEnumerable<CategoryRuleBase> GetPerformancesCategoryRule(InvoiceModel invoice)
        {
            return invoice.Performances.Select(perf =>
            {
                return CategoryBuilder.Create(perf)
                                            .GetCategory()
                                             .CalculateAmount()
                                               .CalculateCredits();
            });
        }
    }
}