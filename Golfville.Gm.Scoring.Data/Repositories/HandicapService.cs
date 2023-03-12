using Golfville.Gm.Scoring.Data.Models;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class HandicapService : IHandicapService
    {
        private readonly IMemberScoreRepository _memberScoreRepository;
        private readonly ICourseRepository _courseRepository;

        public HandicapService(IMemberScoreRepository memberScoreRepository, ICourseRepository courseRepository)
        {
            _memberScoreRepository = memberScoreRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Handicap> Calculate(int memberId)
        {
            var memberScores = await _memberScoreRepository.GetScoresAsync(memberId, 20);
            if (memberScores.Count < 3)
                throw new InvalidOperationException($"Cannot calculate a handicap with less than 3 member scores for memberId = ${memberId}");
            var courseIds = memberScores.Select(x => x.CourseId).ToList();
            var courses = await _courseRepository.GetCoursesAsync(courseIds);
            var handicap = Handicap.Calculate(memberScores, courses);
            return handicap;
        }
    }
}
