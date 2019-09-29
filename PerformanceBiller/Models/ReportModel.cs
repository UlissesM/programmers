using PerformanceBiller.Models.Category;
using System.Collections.Generic;
using System.Globalization;

namespace PerformanceBiller.Models
{
    public class ReportModel
    {
        public string Customer { get; private set; }
        public IEnumerable<CategoryRuleBase> Rules { get; private set; }
        public CultureInfo CultureFormat {get; private set; }

        public static ReportModel Create(string customer, IEnumerable<CategoryRuleBase> rules, string cultureInfo = "en-Us") =>
            new ReportModel
            {
                Customer = customer,
                Rules = rules,
                CultureFormat = new CultureInfo(cultureInfo)
            };
        
    }
}
