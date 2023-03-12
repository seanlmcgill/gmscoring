using Golfville.Gm.Scoring.Data.Models;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public interface IHandicapService
    {
        public Task<Handicap> Calculate(int memberId);
    }
}
