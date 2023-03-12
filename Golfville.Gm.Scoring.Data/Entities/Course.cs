namespace Golfville.Gm.Scoring.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Tee> TeeList { get; set; } = new List<Tee>();
    }
}
