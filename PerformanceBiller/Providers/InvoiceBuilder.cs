using PerformanceBiller.Entities.Perfomance;
using System;

namespace PerformanceBiller.Providers
{
    public class PlayBuilder
    {
        private string name;
        private int audience;

        public void WithName(string name)
        {
            this.name = name;
        }

        public void WithAudience(int audience) 
        {
            this.audience = audience;
        }

        public Play Build(string type)
        {
            switch(type)
            {
                case "comedy":
                    return new Comedy(name, audience);
                case "tragedy":
                    return new Tragedy(name, audience);
                default:
                    throw new ArgumentException($"unknown type: {type}");
            }
        }
    }
}
