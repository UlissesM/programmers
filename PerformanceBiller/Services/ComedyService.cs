namespace PerformanceBiller.Services
{
    public class ComedyService : BasePlayService
    {
        private const int PLAY_AMOUNT = 30000;

        public override int calculateExtraAmountAudience(int audience) =>
            audience > 20
            ? (PLAY_AMOUNT + 1000 + 500 * (audience - 20)) + addExtraAmountAudience(audience)
            : addExtraAmountAudience(audience);

        public override int getPlayAmount() =>
            PLAY_AMOUNT;

        public override int calculateVolumeCredits(int audience) =>
            base.calculateVolumeCredits(audience) + (audience / 5);
        

        private int addExtraAmountAudience(int audience) =>
            300 * audience;
    }
}
