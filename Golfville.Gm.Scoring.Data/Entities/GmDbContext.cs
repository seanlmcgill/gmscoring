using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public class GmDbContext : DbContext, IGmDbContext
    {
        public GmDbContext(DbContextOptions<GmDbContext> options)
            : base(options) { }

        public DbSet<MemberScore> MemberScores { get; set; }
    }
}
