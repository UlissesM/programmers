using PerformanceBiller.Models.Builder;

namespace PerformanceBiller.Models.Category
{
    public class TragedyRule : CategoryRuleBase
    {
        const int valueMaxAudience = 30;

        public TragedyRule(CategoryBuilder builderRule) : base(builderRule)
        {
            Amount = 40000;
        }

        protected override int CalculateExtraCredit()
        {
            return 1000 * (Audiance - valueMaxAudience);
        }

        protected override bool ValidMaxTax()
        {
            return Audiance > valueMaxAudience;
        }
    }
}
