using Golfville.Gm.Scoring.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    /// <summary>
    /// Partial to seed to avoid re-gen overrwrite
    /// </summary>
    public partial class GmDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(CourseSeeder.GetCourses());
            modelBuilder.Entity<TeeBox>().HasData(TeeBoxSeeder.GetTeeBoxes());
        }
    }
}
