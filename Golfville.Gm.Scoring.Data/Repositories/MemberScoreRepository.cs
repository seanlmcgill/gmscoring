using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class MemberScoreRepository : IMemberScoreRepository
    {
        private GmDbContext _gmDbContext;

        public MemberScoreRepository(GmDbContext scoringDbContext)
        {
            _gmDbContext = scoringDbContext;
        }

        public async Task<List<MemberScore>> GetRecentScores(int memberId, int count = 10)
        {
            var scores = await _gmDbContext.MemberScores
                .Where(x => x.MemberId == memberId)
                .Take(count)
                .OrderByDescending(x => x.PostDateTime)
                .Include(x => x.TeeBox)
                .ToListAsync();

            return scores;
        }

        public async Task<List<MemberScore>> GetAllForYearAsync(int year)
        {
            return await _gmDbContext.MemberScores
                .Where(x => x.PostDateTime.Year == year)
                .ToListAsync();
        }

        public async Task<MemberScore> AddScoreAsync(MemberScore memberScore)
        {
            var score = await _gmDbContext.MemberScores.AddAsync(memberScore);
            await _gmDbContext.SaveChangesAsync();
            return score.Entity;
        }
    }
}
