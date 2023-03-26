using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class TeeBoxRepository : ITeeBoxRepository
    {
        private GmDbContext _gmDbContext;

        public TeeBoxRepository(GmDbContext scoringDbContext)
        {
            _gmDbContext = scoringDbContext;
        }

        public async Task<List<TeeBox>> GetTeeBoxAsync(List<int> teeBoxIds)
        {
            if (teeBoxIds.Count == 0)
                return new List<TeeBox>();

            return await _gmDbContext.TeeBoxes
                .Where(x => teeBoxIds.Contains(x.TeeBoxId))
                .Include("Course")
                .ToListAsync();
        }
    }
}
