using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public class ScoringDbContext : DbContext, IScoringDbContext
    {
        public ScoringDbContext(DbContextOptions<ScoringDbContext> options)
            : base(options) { }

        public DbSet<MemberScore> MemberScores { get; set; }
        public DbSet<Course> Courses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<MemberScore>()                                
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Course>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<Tee>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MemberScore>().HasData(SeedGenerator.GetTestMemberScores());
            modelBuilder.Entity<Course>().HasData(SeedGenerator.GetTestCourses());
        }       
    }
}
