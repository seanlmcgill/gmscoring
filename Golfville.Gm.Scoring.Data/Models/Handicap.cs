using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.Models
{
    public class Handicap
    {
        public List<HandicapDifferential> HandicapDifferentials { get; set; } = new();
        public double PlayerHandicap { get; set; }

        public static Handicap Calculate(List<MemberScore> memberScores, List<Course> courses)
        {
            var handicap = new Handicap();            
            var differentialList = new List<HandicapDifferential>();
            foreach (var memberScore in memberScores)
            {
                var course = courses.Where(x => x.Id == memberScore.CourseId).SingleOrDefault();
                if (course != null)
                {
                    var tee = course.TeeList
                        .Where(x => x.Id == memberScore.TeeBoxId)
                        .SingleOrDefault();
                    if (tee == null)
                        continue;
                    
                    // Handicap differential = (Adjusted Gross Score - rating of the course) X 113 / Course slope ratings.                    
                    var differentialValue = (memberScore.Score - tee.Rating) * 113 / tee.Slope;
                    var handicapDifferential = new HandicapDifferential
                    {
                        Course = course.Name,
                        TeeBox = tee.Description,
                        Score = memberScore.Score,
                        Differential = differentialValue,
                        PostDateTime = memberScore.PostingDateTime
                    };
                    differentialList.Add(handicapDifferential);
                }

                differentialList = differentialList.OrderBy(x => x.Differential).ToList();
                handicap.PlayerHandicap = differentialList.Take(8).Average(x => x.Differential);
            }

            return handicap;
        }
    }
}
