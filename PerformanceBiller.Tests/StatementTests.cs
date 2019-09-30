using System;
using System.Linq;
using PerformanceBiller.Services;
using PerformanceBiller.Tests.Mock;
using Xunit;

namespace PerformanceBiller.Tests
{
    public class StatementTests
    {
        private readonly string expectedOutput;

        public StatementTests()
        {
            expectedOutput = "Statement for BigCo\n" +
                " Hamlet: $650.00 (55 seats)\n" +
                " As You Like It: $580.00 (35 seats)\n" +
                " Othello: $500.00 (40 seats)\n" +
                "Amount owed is $1,730.00\n" +
                "You earned 47 credits\n";
        }

        [Fact]
        public void Should_Print_Report()
        {
            var statement = new Statement(new ReportPerformanceService());
            var invoice = InvoiceModelMock.GetInvoiceModelMock();
            var actualResult = statement.PrintReport(invoice);

            Assert.Equal(expectedOutput, actualResult);
        }

        [Fact]
        public void Should_Print_Report_Error_When_Type_Not_Founded()
        {
            var statement = new Statement(new ReportPerformanceService());
            var invoice = InvoiceModelMock.GetInvoiceModelMock();
            invoice.Performances = invoice.Performances.Append(new Models.PerformanceModel
            {
                PlayID = "the-perils-of-pauline",
                Play = new Models.PlayModel
                {
                    Name = "The Perils of Pauline",
                    Type = "melodrama"
                },
                Audience = 50
            });

            Action actual = () => statement.PrintReport(invoice);
            Exception ex = Assert.Throws<ArgumentException>(actual);
            Assert.Equal("unknown type:melodrama", ex.Message);
        }

        [Fact]
        public void Should_Print_Report_Single_With_Culture()
        {
            var statement = new Statement(new ReportPerformanceService());
            var invoice = InvoiceModelMock.GetInvoiceModelMock();
            invoice.Performances = invoice.Performances.Where(a => a.PlayID == "as-like");

            var actualResult = statement.PrintReport(invoice, "pt_BR");
            var expected = "Statement for BigCo\n As You Like It: R$ 580,00 (35 seats)\nAmount owed is R$ 580,00\nYou earned 12 credits\n";

            Assert.Equal(expected, actualResult);
        }

    }
}
