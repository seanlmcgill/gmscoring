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
            modelBuilder.Entity<Course>().HasData(CourseSeeder.Get());
            var teeBoxes = TeeBoxSeeder.Get();
            modelBuilder.Entity<TeeBox>().HasData(teeBoxes);
            var members = MemberSeeder.Get();
            modelBuilder.Entity<Member>().HasData(members);
            modelBuilder
                .Entity<MemberScore>()
                .HasData(new MemberScoreSeeder(members, teeBoxes).Get());
        }
    }
}
