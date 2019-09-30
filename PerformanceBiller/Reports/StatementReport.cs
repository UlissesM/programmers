using System.Globalization;
using System.Linq;
using System.Text;
using PerformanceBiller.Entities;

namespace PerformanceBiller
{
    public class StatementReport
    {
        private CultureInfo cultureInfo;

        public StatementReport(string cultureInfo)
        {
            this.cultureInfo = new CultureInfo(cultureInfo);
        }

        public string Get(Invoice invoice)
        {
            var report = new StringBuilder();
            report.AppendLine($"Statement for {invoice.Customer}");
            invoice.Plays.Select(play => report.AppendLine($" {play.Name}: {FormatAmount(play.Amount)} ({play.Audience} seats)"));
            report.AppendLine($"Amount owed is {FormatAmount(invoice.GetTotalAmount())}")
                .AppendLine($"You earned {invoice.GetTotalVolumeCredits()} credits");
            return report.ToString();
        }

        public string FormatAmount(int value) =>
             (value / 100).ToString("C", cultureInfo);
    }
}
