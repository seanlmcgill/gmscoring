using System;
using System.Collections.Generic;

namespace Golfville.Gm.Scoring.Data.Entities;

public partial class MemberScore
{
    public int MemberScoreId { get; set; }

    public int MemberId { get; set; }

    public int TeeBoxId { get; set; }

    public int Score { get; set; }

    public DateTime PostDateTime { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual TeeBox TeeBox { get; set; } = null!;
}
