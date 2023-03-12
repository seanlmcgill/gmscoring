using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public interface IScoringDbContext
    {
        public DatabaseFacade Database { get; }
        public DbSet<MemberScore> MemberScores { get; set; }
        public DbSet<Course> Courses { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
