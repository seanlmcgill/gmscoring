namespace Golfville.Gm.ScoringRepositories
{
    internal interface IMemberScoreRepository
    {
        List<MemberScore> GetScoresAsync(int userId, int top);
    }
}
