using PerformanceBiller.Models.Builder;

namespace PerformanceBiller.Models.Category
{
    public class ComedyRule : CategoryRuleBase
    {
        const int valueMaxAudience = 20;

        public ComedyRule(CategoryBuilder builderRule) : base(builderRule)
        {
            Amount = 30000;
        }

        protected override int MaxTax()
        {
            return 10000 + 500 * (Audiance - valueMaxAudience);
        }

        protected override bool ValidMaxTax()
        {
            return Audiance > valueMaxAudience;
        }

        protected override int SumTax()
        {
            return Audiance * 300;
        }

        protected override int AddVolumeCreditExtra()
        {
            return Audiance / 5;
        }
    }
}
