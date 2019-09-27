namespace PerformanceBiller.Services
{
    public class TragedyService : BasePlayService
    {
        private const int BONUS = 1000;

        protected override int calculateExtraAmountAudience(int audience) =>
            audience > getMinimumAudience() ? BONUS * (audience - getMinimumAudience()) : 0;

        protected override int getMinimumAudience() => 30;

        protected override int getPlayAmount() => 40000;
    }
}
