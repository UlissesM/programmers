﻿using PerformanceBiller.Models;
using PerformanceBiller.Models.Category;
using PerformanceBiller.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PerformanceBiller.Services
{
    public class ReportPerformanceService : IReportPerformanceService
    {
        private readonly StringBuilder _report;

        public ReportPerformanceService()
        {
            _report = new StringBuilder();
        }

        public string CreateReport(ReportModel reportModel)
        {
            var valueTotalAmount = reportModel.Rules.Sum(rule => rule.Amount);
            var valueTotalVolumeCredits = reportModel.Rules.Sum(rule => rule.VolumeCredit);
            _report.Append($"Statement for {reportModel.Customer}\n");

            foreach (var rule in reportModel.Rules)
            {
                _report.Append($" {rule.Play.Name}: {(rule.Amount / 100).ToString("C", reportModel.CultureFormat)} ({rule.Audiance} seats)\n");
            }

            _report.Append($"Amount owed is {(valueTotalAmount / 100).ToString("C", reportModel.CultureFormat)}\n");
            _report.Append($"You earned {valueTotalVolumeCredits} credits\n");

            return _report.ToString();
        }
    }
}
