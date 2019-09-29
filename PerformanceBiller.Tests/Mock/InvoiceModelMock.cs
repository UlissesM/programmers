using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PerformanceBiller.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PerformanceBiller.Tests.Mock
{
    public static class InvoiceModelMock
    {
        public static InvoiceModel GetInvoiceModelMock()
        {
            using (var invoicesFile = File.OpenText("..\\..\\..\\invoices.json"))
            using (var invoicesReader = new JsonTextReader(invoicesFile))
            using (var playsFile = File.OpenText("..\\..\\..\\plays.json"))
            using (var playsReader = new JsonTextReader(playsFile))
            {
                var invoices = (JArray)JToken.ReadFrom(invoicesReader);
                var invoice = (JObject)invoices.First;
                var plays = (JObject)JToken.ReadFrom(playsReader);
                var playsConverted = JsonConvert.DeserializeObject<Dictionary<string, PlayModel>>(plays.ToString());
                var invoiceConverted = JsonConvert.DeserializeObject<InvoiceModel>(invoice.ToString());
                invoiceConverted.Performances = invoiceConverted.Performances.Select(p => { p.Play = playsConverted[p.PlayID]; return p; });
                return invoiceConverted;
            }
        }
    }
}
