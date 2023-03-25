using Golfville.Gm.Scoring.Data.Repositories;
using Golfville.Gm.Scoring.Data.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golfville.Gm.Scoring.UnitTests.Services
{
    public class HandicapServiceTests
    {
        private Mock<IMemberScoreRepository> _memberScoreRepositoryMock = new Mock<IMemberScoreRepository>();
        private Mock<ICourseRepository> _courseRepositoryMock = new Mock<ICourseRepository>();
        private const int MemberId = 1;
        private const int MaxHandicapScores = 20;

        [Fact]
        public async Task NoScoresForHandicap()
        {
            _memberScoreRepositoryMock.Setup(x => x.GetRecentScores(MemberId, MaxHandicapScores)).ReturnsAsync(new List<Data.Entities.MemberScore>());
            var service = new HandicapService(_memberScoreRepositoryMock.Object, _courseRepositoryMock.Object);
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
            var service = new HandicapService(_memberScoreRepositoryMock.Object, _courseRepositoryMock.Object);
            var handicap = await service.Calculate(MemberId);
            Assert.True(handicap.NotEligible);
        }
    }
}
