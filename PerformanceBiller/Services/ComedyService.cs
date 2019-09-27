namespace PerformanceBiller.Services
{
    public class ComedyService : BasePlayService
    {
        private const int BONUS = 1500;
        private const int EXTRA_AMOUNT = 300;

        protected override int calculateExtraAmountAudience(int audience) =>
            audience > getMinimumAudience()
            ? (getPlayAmount() + BONUS * (audience - getMinimumAudience())) + addExtraAmountAudience(audience)
            : addExtraAmountAudience(audience);

        protected override int getPlayAmount() => 30000;

        public override int calculateVolumeCredits(int audience) =>
            base.calculateVolumeCredits(audience) + (audience / 5);


        public int addExtraAmountAudience(int audience) =>
            EXTRA_AMOUNT * audience;

        protected override int getMinimumAudience() => 20;
    }
}
