namespace Golfville.Gm.Scoring.Data.Entities
{
    public class Tee
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int Slope { get; set; }
    }
}
