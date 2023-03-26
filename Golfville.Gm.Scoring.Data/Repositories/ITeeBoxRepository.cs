using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public interface ITeeBoxRepository
    {
        Task<List<TeeBox>> GetTeeBoxAsync(List<int> teeBoxIds);
    }
}
