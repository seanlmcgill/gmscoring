using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public interface IMemberScoreRepository
    {
        Task<List<MemberScore>> GetScoresAsync(int userId, int top);
        Task<MemberScore> AddScoreAsync(MemberScore memberScore);
    }
}
