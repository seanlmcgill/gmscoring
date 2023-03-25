using System;
using System.Collections.Generic;

namespace Golfville.Gm.Scoring.Data.Entities;

public partial class Member
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<MemberScore> MemberScores { get; } = new List<MemberScore>();
}
