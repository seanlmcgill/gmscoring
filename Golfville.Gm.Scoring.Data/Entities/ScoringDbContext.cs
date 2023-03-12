using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public class ScoringDbContext : DbContext, IScoringDbContext
    {
        public ScoringDbContext(DbContextOptions<ScoringDbContext> options)
            : base(options) { }

        public DbSet<MemberScore> MemberScores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<MemberScore>()                                
                .HasKey(x => x.Id);

            var seedData = GetTestData();

            modelBuilder.Entity<MemberScore>().HasData(seedData);                           
        }

        public MemberScore[] GetTestData()
        {
            var seedScores = new List<MemberScore>();
            var baseDate = new DateTime(2022, 01, 01);
            var random = new Random();
            var postTimeHours = random.Next(11, 16);
            for (var i=0; i<100; i++)
            {
                var memberId = random.Next() % 10;
                var courseId = random.Next() % 6;
                var teeBoxId = random.Next() % 4;
                var score = random.Next(70, 91);
                seedScores.Add(new MemberScore
                {
                    Id = i + 1,
                    MemberId = memberId,
                    CourseId = courseId,
                    TeeBoxId = teeBoxId,
                    Score = score,
                    PostingDateTime = baseDate + new TimeSpan(i + 2, postTimeHours, 0, 0)
                });
            }

            return seedScores.ToArray();
        }
    }
}
