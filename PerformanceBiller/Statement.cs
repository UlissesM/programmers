using Newtonsoft.Json.Linq;
using PerformanceBiller.Models;
using PerformanceBiller.Providers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PerformanceBiller
{
    public class Statement
    {
        public string Run(JObject invoice, IEnumerable<PlayModel> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var result = $"Statement for {invoice.GetValue("customer")}\n";
            var cultureInfo = new CultureInfo("en-US");
            var playProvider = new PlayProvider();

            foreach (JObject perf in invoice.GetValue("performances"))
            {
                var play = plays.FirstOrDefault(p => p.Name.Equals(perf.GetValue("playID").ToString()));
                var playAmount = playProvider.GetPlayService(play.Type.ToString().ToLower()).calculateTotalAmount(Convert.ToInt32(perf.GetValue("audience")));
                totalAmount += playAmount;
                volumeCredits += playProvider.GetPlayService(play.Type.ToString().ToLower()).calculateVolumeCredits(Convert.ToInt32(perf.GetValue("audience")));
            }

            return string.Empty;
        }
    }
}
