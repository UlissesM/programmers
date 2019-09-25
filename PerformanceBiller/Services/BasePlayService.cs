using System;
using PerformanceBiller.Services.Interface;

namespace PerformanceBiller.Services
{
    public abstract class BasePlayService : IPlayService
    {
        public virtual int calculateTotalAmount(int audience) =>
            getPlayAmount() + calculateExtraAmountAudience(audience);

        public virtual int calculateVolumeCredits(int audience) =>
            Math.Max(audience - 30, 0);

        public abstract int getPlayAmount();
        public abstract int calculateExtraAmountAudience(int audience);
    }
}
