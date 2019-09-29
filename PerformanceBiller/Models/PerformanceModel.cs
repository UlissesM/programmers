namespace PerformanceBiller.Models
{
    public class PerformanceModel
    {
        public string PlayID { get; set; }
        public PlayModel Play { get; set; }

        public int Audience { get; set; }
    }
}
