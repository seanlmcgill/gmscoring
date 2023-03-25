using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Models;
using Golfville.Gm.Scoring.Data.Repositories;

namespace Golfville.Gm.Scoring.Data.Services
{
    public class HandicapService : IHandicapService
    {
        private const int HandicapScoreCount = 20;
        private const int MinScoresRequiredForHandicap = 3;

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

        public async Task<Handicap> Calculate(int memberId)
        {
            var memberScores = await _memberScoreRepository.GetRecentScores(
                memberId,
                HandicapScoreCount
            );

            if (memberScores.Count < MinScoresRequiredForHandicap)
                return new Handicap { NotEligible = true };            
            
            var handicap = Calculate(memberScores);

            return handicap;            
        }

        private static Handicap Calculate(List<MemberScore> handicapScores)
        {
            var handicap = new Handicap();
            var differentialList = new List<HandicapDifferential>();

            // x => (x.Score - x.TeeBox.Rating) * 113 / x.TeeBox.Slope)
            // Handicap differential = (Adjusted Gross Score - rating of the course) X 113 / Course slope ratings.
            var differentials = handicapScores.Select(x =>
                                    new HandicapDifferential
                                    {
                                        Course = "",
                                        TeeBox = "",
                                        Score = 0,
                                        Differential = 0,
                                        PostDateTime = DateTime.MinValue
                                    }).ToList();
                                   

            //foreach (var memberScore in memberScores)
            //{
            //    var course = courses.TeeBoxe
            //        .Where(x => x.CourseId == memberScore.CourseId)
            //        .SingleOrDefault();
            //    if (course != null)
            //    {
            //        var tee = course.TeeList
            //            .Where(x => x.Id == memberScore.TeeBoxId)
            //            .SingleOrDefault();
            //        if (tee == null)
            //            continue;

                    
            //        var differentialValue = (memberScore.Score - tee.Rating) * 113 / tee.Slope;
            //        var handicapDifferential = new HandicapDifferential
            //        {
            //            Course = course.Name,
            //            TeeBox = tee.Description,
            //            Score = memberScore.Score,
            //            Differential = differentialValue,
            //            PostDateTime = memberScore.PostDateTime
            //        };
            //        differentialList.Add(handicapDifferential);
            //    }

            //    differentialList = differentialList.OrderBy(x => x.Differential).ToList();
            //    handicap.PlayerHandicap = differentialList.Take(8).Average(x => x.Differential);
            //}

            return handicap;            
        }
    }
}
