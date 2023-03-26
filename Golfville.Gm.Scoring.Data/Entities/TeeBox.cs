namespace Golfville.Gm.Scoring.Data.Entities;

public partial class TeeBox
{
    public int TeeBoxId { get; set; }

    public int CourseId { get; set; }

    public TeeColor TeeColor { get; set; }

    public string Name { get; set; } = null!;

    public int Slope { get; set; }

    public decimal Rating { get; set; }

    public virtual Course Course { get; } = null;
}
