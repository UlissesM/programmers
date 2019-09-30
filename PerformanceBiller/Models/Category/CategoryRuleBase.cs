using PerformanceBiller.Models.Builder;
using System;

namespace PerformanceBiller.Models.Category
{
    public abstract class CategoryRuleBase
    {
        protected CategoryRuleBase(CategoryBuilder builderRule)
        {
            Audiance = builderRule.Audience;
            Play = builderRule.Play;
        }

        public int Amount { get; set; }
        public int Audiance { get; set; }
        public int VolumeCredit { get; set; }
        public PlayModel Play { get; set; }
        protected abstract bool ValidMaxTax();
        protected abstract int CalculateExtraCredit();

        public CategoryRuleBase CalculateCredits()
        {
            VolumeCredit += Math.Max(Convert.ToInt32(Audiance) - 30, 0);
            VolumeCredit += AddVolumeCreditExtra();
            return this;
        }

        public CategoryRuleBase CalculateAmount()
        {
            if (ValidMaxTax())
                Amount += CalculateExtraCredit();

            Amount += SumTax();
            return this;
        }

        protected virtual int SumTax() => 0;
        protected virtual int AddVolumeCreditExtra() => 0;
    }
}

