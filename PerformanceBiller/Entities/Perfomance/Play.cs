using System;
namespace PerformanceBiller.Entities.Perfomance
{
    public abstract class PlayType
    {
        public string Name { get; private set; }
        public int Audience { get; protected set; }
        public int Amount { get; protected set; }
        public int Credits { get; set; }

        public virtual PlayType calculateAmount()
        {
            Amount = getPlayAmount() + calculateExtraAmountAudience();
            return this;
        }

        public virtual PlayType calculateVolumeCredits()
        {
            Credits += Math.Max(Audience - getMinimumAudience(), 0);
            Credits += AddExtraCredit();
            return this;
        }


        protected virtual bool isAudienceBiggerThanMinimium() =>
            Audience > getMinimumAudience();

        protected abstract int getPlayAmount();
        protected abstract int calculateExtraAmountAudience();
        protected abstract int getMinimumAudience();
        protected virtual int AddExtraCredit() => 0;
    }
}
