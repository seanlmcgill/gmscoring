namespace Golfville.Gm.Scoring.Data.Models
{
    public class Handicap
    {
        public static int HandicapScoreCount = 20;

        public List<HandicapDifferential> HandicapDifferentials { get; set; } = new();
        public double PlayerHandicap { get; set; }
        public bool NotEligible { get; set; }
    }
}
