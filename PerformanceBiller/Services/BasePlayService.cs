using PerformanceBiller.Services.Interface;

namespace PerformanceBiller.Services
{
    public abstract class BasePlayService : IPlayService
    {
        public virtual int calculateTotalAmount(int audience) =>
            getPlayAmount() + calculateExtraAmountAudience(audience);

        public abstract int getPlayAmount();
        public abstract int calculateExtraAmountAudience(int audience);
    }
}
