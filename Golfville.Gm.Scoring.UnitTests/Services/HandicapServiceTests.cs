using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Repositories;
using Golfville.Gm.Scoring.Data.Services;
using Moq;

namespace Golfville.Gm.Scoring.UnitTests.Services
{
    public class HandicapServiceTests
    {
        private readonly Mock<IMemberScoreRepository> _memberScoreRepositoryMock = new();
        private readonly Mock<ICourseRepository> _courseRepositoryMock = new();
        private const int MemberId = 1;
        private readonly List<MemberScore> _testScores;
        private readonly List<Course> _courses;
        private readonly TeeBox _teeBoxOne;
        private readonly TeeBox _teeBoxTwo;

        public HandicapServiceTests()
        {
            _teeBoxOne = new TeeBox
            {
                CourseId = 1,
                Name = string.Empty,
                Slope = 137,
                Rating = 74.3m
            };

            _teeBoxTwo = new TeeBox
            {
                CourseId = 2,
                Name = string.Empty,
                Slope = 141,
                Rating = 76.0m
            };

            _courses = new List<Course>
            {
                new Course { CourseId = 1, Name = "course 1" },
                new Course { CourseId = 2, Name = "course 2" },
            };

            _testScores = new List<MemberScore>();
            var baseDate = new DateTime(2023, 3, 25);
            for (var i = 0; i < 50; i++)
            {
                _testScores.Add(
                    new MemberScore
                    {
                        Score = 80,
                        PostDateTime = baseDate + new TimeSpan(1, 0, 0, 0),
                        TeeBox = i % 2 == 0 ? _teeBoxOne : _teeBoxTwo
                    }
                );
            }

            _courseRepositoryMock
                .Setup(x => x.GetCoursesAsync(string.Empty))
                .ReturnsAsync(_courses);

            var distinctCourses = _courses.Select(x => x.CourseId).Distinct().ToList();
            _courseRepositoryMock
                .Setup(x => x.GetCoursesAsync(distinctCourses))
                .ReturnsAsync(_courses);
        }

        [Fact]
        public async Task ShouldNotBeEligibile_NoScores()
        {
            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(new List<MemberScore>());
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.False(handicap.Eligible);
        }

        [Fact]
        public async Task ShouldNotBeEligibile_NotEnoghScores()
        {
            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(
                    _testScores.Take(HandicapService.MinScoresRequiredForHandicap - 1).ToList()
                );
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.False(handicap.Eligible);
        }

        [Fact]
        public async Task ShouldBeEligibile_MinScoresRequired()
        {
            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(
                    _testScores.Take(HandicapService.MinScoresRequiredForHandicap).ToList()
                );
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.True(handicap.Eligible);
        }

        [Fact]
        public async Task ShouldBeEligibile_ExactScoresRequired()
        {
            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(_testScores.Take(HandicapService.HandicapScoreCount).ToList());
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.True(handicap.Eligible);
        }

        [Fact]
        public async Task ShouldBeEligibile_MoreThanEnoghScores()
        {
            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(_testScores);
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.True(handicap.Eligible);
        }

        [Fact]
        public async Task HandicapCalculation_ShouldBeCorrect()
        {
            const double expectedHandicap = 3.1;

            _memberScoreRepositoryMock
                .Setup(x => x.GetRecentScores(MemberId, HandicapService.HandicapScoreCount))
                .ReturnsAsync(_testScores);
            var service = new HandicapService(
                _memberScoreRepositoryMock.Object,
                _courseRepositoryMock.Object
            );
            var handicap = await service.CalculateAsync(MemberId);
            Assert.Equal(expectedHandicap, handicap.PlayerHandicap);
        }
    }
}
