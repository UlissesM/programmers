using PerformanceBiller.Models.Category;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PerformanceBiller.Models
{
    public class ReportModel
    {
        public string Customer { get; private set; }
        public IEnumerable<CategoryRuleBase> Rules { get; private set; }
        public CultureInfo CultureFormat {get; private set; }
        public int TotalAmount { get; private set; }
        public int TotalCredits { get; private set; }


        public static ReportModel Create(string customer, IEnumerable<CategoryRuleBase> rules, string cultureInfo = "en-Us") =>
            new ReportModel
            {
                Customer = customer,
                Rules = rules,
                CultureFormat = new CultureInfo(cultureInfo),
                TotalAmount = rules.Sum(_=> _.Amount),
                TotalCredits = rules.Sum(_=> _.VolumeCredit)
            };
        
    }
}
