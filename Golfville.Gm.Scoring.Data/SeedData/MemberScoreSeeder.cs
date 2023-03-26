using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.SeedData
{
    internal class MemberScoreSeeder
    {
        private List<Member> _members;
        private List<TeeBox> _teeBoxes;
        private Random _random = new();
        private const int PostHourMin = 10;
        private const int PostHourMax = 18;
        private const int YearRoundsMin = 25;
        private const int YearRoundsMax = 125;
        private int _memberScoreId = 1;

        public MemberScoreSeeder(List<Member> members, List<TeeBox> teeBoxes)
        {
            _members = members;
            _teeBoxes = teeBoxes;
        }

        public List<MemberScore> Get()
        {
            var memberScores = new List<MemberScore>();

            if (!_members.Any())
                return memberScores;

            // Generate scores for past 3 years 
            _members.ForEach(m =>
            {
                var startYear = DateTime.Now.Year - 3;
                for (var i = startYear; i <= startYear + 3; i++)
                    memberScores.AddRange(GenerateForMemberYear(i, m));
            });

            return memberScores;
        }

        /// <summary>
        /// Generate scores for a member for a year
        /// </summary>        
        private List<MemberScore> GenerateForMemberYear(int year, Member member)
        {
            var memberScores = new List<MemberScore>();
            var baseDate = new DateTime(year, 1, 1);
            var totalRoundsForYear = _random.Next(YearRoundsMin, YearRoundsMax);
            var memberYearScoreMin = _random.Next(65, 80);
            var memberYearScoreMax = _random.Next(80, 100);

            // Generate a randomized amount of scores for the year at random courses (ie. tee-boxes)            
            for (var i = 0; i < totalRoundsForYear; i++)
                memberScores.AddRange(GenerateRanomMemberScore(baseDate, member, memberYearScoreMin, memberYearScoreMax));

            return memberScores;
        }

        /// <summary>
        /// Generate a random member score
        /// </summary>        
        private List<MemberScore> GenerateRanomMemberScore(DateTime baseDate, Member member, int scoreMin, int scoreMax)
        {
            var memberScores = new List<MemberScore>();
            var postTimeHours = _random.Next(PostHourMin, PostHourMax);
            var randomTeeIndex = _random.Next(0, _teeBoxes.Count() - 1);
            var teeBox = _teeBoxes[randomTeeIndex];
            var score = _random.Next(scoreMin, scoreMax);
            var dayIteration = _random.Next(1, 3);

            memberScores.Add(
                new MemberScore
                {
                    MemberScoreId = _memberScoreId++,
                    MemberId = member.MemberId,
                    TeeBoxId = teeBox.TeeBoxId,
                    Score = score,
                    PostDateTime = baseDate + new TimeSpan(dayIteration, postTimeHours, 0, 0)
                }
            );

            return memberScores;
        }
    }
}
