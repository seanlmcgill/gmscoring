using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    /// <summary>
    /// Partial to seed to avoid re-gen overrwrite
    /// </summary>
    public partial class GmDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(SeedGenerator.GetTestCourses());
            builder.Entity<TeeBox>().HasData(SeedGenerator.GetTeeBoxes());
        }
    }
}
