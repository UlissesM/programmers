namespace PerformanceBiller.Models
{
    public class PerformanceModel
    {
        public string PlayId { get; set; }

        public PlayModel Play { get; set; }

        public int Audience { get; set; }
    }
}
