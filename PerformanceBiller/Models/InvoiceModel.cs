﻿using System.Collections.Generic;

namespace PerformanceBiller.Models
{
    public class InvoiceModel
    {
        public string Customer { get; set; }

        public IEnumerable<PerformanceModel> Perfomances { get; set; }
    }
}
