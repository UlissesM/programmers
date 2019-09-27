using PerformanceBiller.Services;
using System;

namespace PerformanceBiller.Providers
{
    public class PlayProvider
    {
        private BasePlayService tragedyService;

        private BasePlayService comedyService;

        public BasePlayService GetPlayService(string type)
        {
            switch(type)
            {
                case "comedy":
                    if (comedyService == null) comedyService = new ComedyService();
                    return comedyService;
                case "tragedy":
                    if (tragedyService == null) tragedyService = new TragedyService();
                    return tragedyService;
                default:
                    throw new ArgumentException($"unknown type: {type}");
            }
        }
    }
}
