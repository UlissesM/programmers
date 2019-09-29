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
        public void Statement_can_run()
        {
            var statement = new Statement(new ReportPerformanceService());
            var invoice = InvoiceModelMock.GetInvoiceModelMock();
            var actualResult = statement.PrintReport(invoice);

            Assert.Equal(expectedOutput, actualResult);
        }

    }
}
