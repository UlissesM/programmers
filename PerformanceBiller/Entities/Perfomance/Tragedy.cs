namespace PerformanceBiller.Entities.Play
{
    public class Tragedy : PlayType
    {
        private const int BONUS = 1000;

        protected override int calculateExtraAmountAudience() =>
            isAudienceBiggerThanMinimium() ? BONUS * (Audience - getMinimumAudience()) : 0;

        protected override int getMinimumAudience() => 30;

        protected override int getPlayAmount() => 40000;
    }
}
