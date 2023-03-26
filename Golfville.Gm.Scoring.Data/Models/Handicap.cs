namespace Golfville.Gm.Scoring.Data.Models
{
    public class Handicap
    {
        public List<HandicapDifferential> HandicapDifferentials { get; set; } = new();
        public double PlayerHandicap { get; set; }
        public bool Eligible { get; set; }
    }
}
