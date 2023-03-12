using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class MemberScoreRepository : IMemberScoreRepository
    {
        private IScoringDbContext _scoringDbContext;

        public MemberScoreRepository(IScoringDbContext scoringDbContext)
        {
            _scoringDbContext = scoringDbContext;
        }

        public Task<List<MemberScore>> GetScoresAsync(int memberId, int? top)
        {
            var query = _scoringDbContext.MemberScores.Where(x => x.MemberId == memberId);

            if (top != null)
                query = query.Take(top.Value);

            return query.ToListAsync();
        }

        public async Task<List<MemberScore>> GetAllForYearAsync(int year)
        {
            return await _scoringDbContext.MemberScores
                .Where(x => x.PostingDateTime.Year == year)
                .ToListAsync();
        }

        public async Task<MemberScore> AddScoreAsync(MemberScore memberScore)
        {
            var score = await _scoringDbContext.MemberScores.AddAsync(memberScore);
            _scoringDbContext.SaveChanges();
            return score.Entity;
        }
    }
}
