using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.SeedData
{
    internal class MemberScoresSeeder
    {
        public static MemberScore[] Get()
        {
            var seedScores = new List<MemberScore>();
            var baseDate = new DateTime(2022, 01, 01);
            var random = new Random();
            var postTimeHours = random.Next(11, 16);
            for (var i = 0; i < 100; i++)
            {
                var memberId = random.Next() % 10;
                var teeBoxId = random.Next() % 4;
                var score = random.Next(70, 91);
                seedScores.Add(
                    new MemberScore
                    {
                        MemberScoreId = i + 1,
                        MemberId = memberId,
                        TeeBoxId = teeBoxId,
                        Score = score,
                        PostDateTime = baseDate + new TimeSpan(i + 2, postTimeHours, 0, 0)
                    }
                );
            }

            return seedScores.ToArray();
        }
    }
}
