using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public interface IScoringDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<MemberScore> MemberScores { get; set; }
        int SaveChanges();
    }
}
