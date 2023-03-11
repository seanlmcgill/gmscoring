using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Golfville.Gm.Scoring.Data.Entities
{
    [Table("memberscore")]
    public class MemberScore
    {
        public int Id { get; set; }

        [Key]
        public int MemberId { get; set; }
        public int CourseId { get; set; }
        public int TeeBoxId { get; set; }
        public int Score { get; set; }
    }
}
