using PerformanceBiller.Models.Category;
using System;

namespace PerformanceBiller.Models.Builder
{
    public class CategoryBuilder
    {
        private CategoryBuilder() { }

        public PlayModel Play { get; private set; }
        public int Audience { get; private set; }

        public static CategoryBuilder Create(PerformanceModel performanceModel)
        {
            return new CategoryBuilder
            {
                Play = performanceModel.Play,
                Audience = performanceModel.Audience
            };
        }

        public CategoryRuleBase Build()
        {
            switch (Play.Type)
            {
                case "tragedy":
                    return new TragedyRule(this);
                case "comedy":
                    return new ComedyRule(this);
                default:
                    throw new ArgumentException($"unknown type:{Play.Type}");
            }
        }
    }
}
