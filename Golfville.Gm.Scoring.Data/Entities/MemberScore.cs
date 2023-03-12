namespace Golfville.Gm.Scoring.Data.Entities
{    
    public class MemberScore
    {
        public int Id { get; set; } 
        public int MemberId { get; set; }
        public int CourseId { get; set; }
        public int TeeBoxId { get; set; }
        public int Score { get; set; }
        public DateTime PostingDateTime { get; set; }
    }
}
