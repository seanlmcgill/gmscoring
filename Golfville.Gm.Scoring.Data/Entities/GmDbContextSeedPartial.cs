using Golfville.Gm.Scoring.Data.SeedData;
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
            builder.Entity<Course>().HasData(CourseSeeder.GetCourses());
            builder.Entity<TeeBox>().HasData(TeeBoxSeeder.GetTeeBoxes());
        }
    }
}
