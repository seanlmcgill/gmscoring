using Golfville.Gm.Scoring.Data.Repositories;
using Golfville.Gm.Scoring.Data.Services;
using Moq;

namespace Golfville.Gm.Scoring.UnitTests.Services
{
    public class HandicapServiceTests
    {
        private readonly Mock<IMemberScoreRepository> _memberScoreRepositoryMock = new();
        private readonly Mock<ITeeBoxRepository> _teeBoxRepositoryMock = new();
        private const int MemberId = 1;
        private const int MaxHandicapScores = 20;

        [Fact]
        public async Task NoScoresForHandicap()
        {
            _memberScoreRepositoryMock.Setup(x => x.GetRecentScores(MemberId, MaxHandicapScores)).ReturnsAsync(new List<Data.Entities.MemberScore>());
            var service = new HandicapService(_memberScoreRepositoryMock.Object, _teeBoxRepositoryMock.Object);
            var handicap = await service.Calculate(MemberId);
            Assert.True(handicap.NotEligible);
        }

        [Fact]
        public async Task MinScoresForHandicap()
        {


            _memberScoreRepositoryMock.Setup(x => x.GetRecentScores(MemberId, MaxHandicapScores)).ReturnsAsync(new List<Data.Entities.MemberScore>
            {
                new Data.Entities.MemberScore
                {

                }
            });
            var service = new HandicapService(_memberScoreRepositoryMock.Object, _teeBoxRepositoryMock.Object);
            var handicap = await service.Calculate(MemberId);
            Assert.True(handicap.NotEligible);
        }
    }
}
