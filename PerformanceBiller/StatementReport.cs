using System.Globalization;

namespace PerformanceBiller
{
    public class StatementReport
    {
        private CultureInfo _cultureInfo;

        public StatementReport(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public static CultureInfo EnglishCulture => new CultureInfo("en - US");


    }
}
