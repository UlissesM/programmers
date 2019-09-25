namespace PerformanceBiller.Services
{
    public class TragedyService : BasePlayService
    {
        private const int PLAY_AMOUNT = 40000;

        public override int calculateExtraAmountAudience(int audience) =>
            audience > 30 ? 1000 * (audience - 30) : 0;

        public override int getPlayAmount() =>
            PLAY_AMOUNT;
    }
}
