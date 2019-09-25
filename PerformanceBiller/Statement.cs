using Newtonsoft.Json.Linq;
using PerformanceBiller.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

            foreach (JObject perf in invoice.GetValue("performances")) {
                var play = plays.FirstOrDefault(p => p.Name.Equals(perf.GetValue("playID").ToString()));
                var thisAmount = 0;
                switch (play.Type.ToString().ToLower()) {
                    case "tragedy":
                        thisAmount = 40000;
                        if (Convert.ToInt32(perf.GetValue("audience")) > 30) {
                            thisAmount += 1000 * (Convert.ToInt32(perf.GetValue("audience")) - 30);
                        }   
                        break;
                    case "comedy":
                        thisAmount = 30000;
                        if (Convert.ToInt32(perf.GetValue("audience")) > 20) {
                            thisAmount += 10000 + 500 * (Convert.ToInt32(perf.GetValue("audience")) - 20);
                        }
                        thisAmount += 300 * Convert.ToInt32(perf.GetValue("audience"));
                        break;
                    default:
                        throw new Exception($"unknown type: { play.Type.ToString()}");
                }
                // add volume credits
                volumeCredits += Math.Max(Convert.ToInt32(perf.GetValue("audience")) - 30, 0);
                // add extra credit for every ten comedy attendees
                if ("comedy" == play.Type.ToString()) volumeCredits += Convert.ToInt32(perf.GetValue("audience")) / 5;
                // print line for this order
                result += $" {play.Name}: {(thisAmount/100).ToString("C", cultureInfo)} ({perf.GetValue("audience")} seats)\n";
                totalAmount += thisAmount;
             }
             result += $"Amount owed is {(totalAmount/100).ToString("C", cultureInfo)}\n";
             result += $"You earned {volumeCredits} credits\n";

             return result;
        }
    }
}
