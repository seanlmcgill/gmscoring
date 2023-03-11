using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class MemberScoreRepository : IMemberScoreRepository
    {
        private IGmDbContext _gmDbContext;

        public MemberScoreRepository(IGmDbContext gmDbContext)
        {
            _gmDbContext = gmDbContext;
        }

        public Task<List<MemberScore>> GetScoresAsync(int memberId, int top)
        {
            return _gmDbContext.MemberScores.Where(x => x.MemberId == memberId).ToListAsync();
        }

        public async Task<MemberScore> AddScoreAsync(MemberScore memberScore)
        {
            var score = await _gmDbContext.MemberScores.AddAsync(memberScore);
            await _gmDbContext.SaveChangesAsync();
            return score.Entity;
        }
    }
}
