using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Models;
using Golfville.Gm.Scoring.Data.Repositories;

namespace Golfville.Gm.Scoring.Data.Services
{
    public class HandicapService : IHandicapService
    {
        public const int HandicapScoreCount = 20;
        public const int MinScoresRequiredForHandicap = 10;

        private readonly IMemberScoreRepository _memberScoreRepository;
        private readonly ICourseRepository _courseRepository;

        public HandicapService(
            IMemberScoreRepository memberScoreRepository,
            ICourseRepository courseRepository
        )
        {
            _memberScoreRepository = memberScoreRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Handicap> CalculateAsync(int memberId)
        {
            var memberScores = await _memberScoreRepository.GetRecentScores(
                memberId,
                HandicapScoreCount
            );

            if (memberScores.Count < MinScoresRequiredForHandicap)
                return new Handicap { Eligible = false };

            var handicap = await CalculateAsync(memberScores);

            return handicap;
        }

        private async Task<Handicap> CalculateAsync(List<MemberScore> handicapScores)
        {
            if (handicapScores.Count < MinScoresRequiredForHandicap)
                throw new InvalidOperationException(
                    "Cannot calculate handicap with less than 3 scores"
                );

            var distinctCourseIds = handicapScores
                .Select(x => x.TeeBox.CourseId)
                .Distinct()
                .ToList();
            var courses = await _courseRepository.GetCoursesAsync(distinctCourseIds);

            // x => (x.Score - x.TeeBox.Rating) * 113 / x.TeeBox.Slope)
            // Handicap differential = (Adjusted Gross Score - rating of the course) X 113 / Course slope ratings.
            var differentials = handicapScores
                .Select(
                    x =>
                        new HandicapDifferential
                        {
                            Course =
                                courses.SingleOrDefault(c => c.CourseId == x.TeeBox.CourseId)?.Name
                                ?? string.Empty,
                            TeeBox = x.TeeBox.Name,
                            Score = x.Score,
                            Differential =
                                (double)((x.Score - x.TeeBox.Rating) * 113) / x.TeeBox.Slope,
                            PostDateTime = x.PostDateTime
                        }
                )
                .ToList();

            // Depending on sore count, differential count adjusts
            int differentialsCountToUse;
            var count = differentials.Count;
            if (count >= MinScoresRequiredForHandicap && count < 15)
                differentialsCountToUse = 3;
            else if (count >= 15 && count < 20)
                differentialsCountToUse = 6;
            else if (count >= 20)
                differentialsCountToUse = 10;
            else
                throw new InvalidOperationException(
                    $"Cannot calculiate handicap with less than {MinScoresRequiredForHandicap} differentials"
                );

            var handicapValue = differentials
                .OrderBy(x => x.Differential)
                .Take(differentialsCountToUse)
                .Average(x => x.Differential);

            handicapValue = double.Round(handicapValue * 0.96, 1);

            return new Handicap
            {
                HandicapDifferentials = differentials,
                PlayerHandicap = handicapValue,
                Eligible = true
            };
        }
    }
}
