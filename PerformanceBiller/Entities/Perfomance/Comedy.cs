namespace PerformanceBiller.Entities.Play
{
    public class Comedy : PlayType
    {
        private const int BONUS = 1500;
        private const int EXTRA_AMOUNT = 300;

        protected override int calculateExtraAmountAudience() =>
            isAudienceBiggerThanMinimium()
            ? (getPlayAmount() + BONUS * (Audience - getMinimumAudience())) + addExtraAmountAudience()
            : addExtraAmountAudience();

        protected override int getPlayAmount() => 30000;

        protected override int AddExtraCredit() => Audience / 5;   

        public int addExtraAmountAudience() =>
            EXTRA_AMOUNT * Audience;

        protected override int getMinimumAudience() => 20;
    }
}
