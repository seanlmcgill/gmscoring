using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Entities
{
    public interface IGmDbContext
    {
        public DbSet<MemberScore> MemberScores { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
