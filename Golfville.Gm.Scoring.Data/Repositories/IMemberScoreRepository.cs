using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public interface IMemberScoreRepository
    {
        Task<List<MemberScore>> GetAllForYearAsync(int year);
        Task<List<MemberScore>> GetRecentScores(int userId, int count = 10);
        Task<MemberScore> AddScoreAsync(MemberScore memberScore);
    }
}
