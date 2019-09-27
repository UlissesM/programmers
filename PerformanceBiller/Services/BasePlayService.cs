using System;

namespace PerformanceBiller.Services
{
    public abstract class BasePlayService
    {
        public virtual int calculateTotalAmount(int audience) =>
            getPlayAmount() + calculateExtraAmountAudience(audience);

        public virtual int calculateVolumeCredits(int audience) =>
            Math.Max(audience - getMinimumAudience(), 0);

        protected abstract int getPlayAmount();
        protected abstract int calculateExtraAmountAudience(int audience);
        protected abstract int getMinimumAudience();
    }
}
