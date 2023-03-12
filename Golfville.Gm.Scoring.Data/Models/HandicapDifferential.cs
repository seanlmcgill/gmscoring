namespace Golfville.Gm.Scoring.Data.Models
{
    public class HandicapDifferential
    {
        public string Course { get; set; } = string.Empty;
        public string TeeBox { get; set; } = string.Empty;
        public int Score { get; set; }
        public double Differential { get; set; }
        public DateTime PostDateTime { get; set; }
    }
}
