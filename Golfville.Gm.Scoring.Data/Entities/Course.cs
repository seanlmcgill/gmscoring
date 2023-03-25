using System;
using System.Collections.Generic;

namespace Golfville.Gm.Scoring.Data.Entities;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public bool PublicAccess { get; set; }

    public virtual ICollection<TeeBox> TeeBoxes { get; } = new List<TeeBox>();
}
