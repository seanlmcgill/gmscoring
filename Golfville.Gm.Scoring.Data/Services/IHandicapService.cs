using Golfville.Gm.Scoring.Data.Models;

namespace Golfville.Gm.Scoring.Data.Services
{
    public interface IHandicapService
    {
        public Task<Handicap> Calculate(int memberId);
    }
}
