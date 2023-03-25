namespace Golfville.Gm.Scoring.Data.Entities
{
    public class SeedGenerator
    {
        public static MemberScore[] GetTestMemberScores()
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

        public static Course[] GetTestCourses()
        {
            var courseList = new List<Course>()
            {
                new()
                {
                    CourseId = 1,
                    Name = "TPC Sawgrass",
                    AddressLine1 = "110 Championship Way",
                    City = "Ponte Vedra Beach",
                    StateCode = "FL",
                    PostalCode = "32082",
                    PublicAccess = false
                },
                new()
                {
                    CourseId = 2,
                    Name = "Lederach",
                    AddressLine1 = "900 Clubhouse Dr",
                    City = "Harleysville",
                    StateCode = "PA",
                    PostalCode = "19438",
                    PublicAccess = true
                },
                new()
                {
                    CourseId = 3,
                    Name = "Scotland Run",
                    AddressLine1 = "2626 Fries Mill Rd",
                    City = "Williamstown",
                    StateCode = "NJ",
                    PostalCode = "08094",
                    PublicAccess = true
                },
                new()
                {
                    CourseId = 4,
                    Name = "Twisted Dune Golf Club",
                    AddressLine1 = "2101 Ocean Heights Ave",
                    City = "Egg Harbor Township",
                    StateCode = "NJ",
                    PostalCode = "08234",
                    PublicAccess = true
                },
                new()
                {
                    CourseId = 5,
                    Name = "Makefield Highlands Golf Club",
                    AddressLine1 = "1418 Woodside Rd",
                    City = "Yardley",
                    StateCode = "PA",
                    PostalCode = "19067",
                    PublicAccess = true
                }
            };

            return courseList.ToArray();
        }

        public static List<TeeBox> GetTeeBoxes()
        {
            var teeBoxes = new List<TeeBox>()
            {
                new()
                {
                    TeeBoxId = 1,
                    CourseId = 1,
                    Name = "The Players",
                    Rating = 76.8m,
                    Slope = 155
                },
                new()
                {
                    TeeBoxId = 2,
                    CourseId = 1,
                    Name = "Blue",
                    Rating = 73.9m,
                    Slope = 148
                },
                new()
                {
                    TeeBoxId = 3,
                    CourseId = 1,
                    Name = "White",
                    Rating = 70.8m,
                    Slope = 138
                },
                new()
                {
                    TeeBoxId = 4,
                    CourseId = 1,
                    Name = "Green",
                    Rating = 65.8m,
                    Slope = 116
                },
                new()
                {
                    TeeBoxId = 5,
                    CourseId = 2,
                    Name = "Black",
                    Rating = 73.9m,
                    Slope = 137
                },
                new()
                {
                    TeeBoxId = 6,
                    CourseId = 2,
                    Name = "Blue",
                    Rating = 71.8m,
                    Slope = 134
                },
                new()
                {
                    TeeBoxId = 7,
                    CourseId = 2,
                    Name = "Green",
                    Rating = 69.8m,
                    Slope = 134
                },
                new()
                {
                    TeeBoxId = 8,
                    CourseId = 2,
                    Name = "White",
                    Rating = 64.3m,
                    Slope = 131
                },
                new()
                {
                    TeeBoxId = 9,
                    CourseId = 3,
                    Name = "Black",
                    Rating = 73.2m,
                    Slope = 136
                },
                new()
                {
                    TeeBoxId = 10,
                    CourseId = 3,
                    Name = "Blue",
                    Rating = 71.8m,
                    Slope = 133
                },
                new()
                {
                    TeeBoxId = 11,
                    CourseId = 3,
                    Name = "Green",
                    Rating = 70.9m,
                    Slope = 128
                },
                new()
                {
                    TeeBoxId = 12,
                    CourseId = 3,
                    Name = "White",
                    Rating = 67.4m,
                    Slope = 118
                },
                new()
                {
                    TeeBoxId = 13,
                    CourseId = 4,
                    Name = "Black",
                    Rating = 74.9m,
                    Slope = 130
                },
                new()
                {
                    TeeBoxId = 14,
                    CourseId = 4,
                    Name = "Blue",
                    Rating = 72.1m,
                    Slope = 126
                },
                new()
                {
                    TeeBoxId = 15,
                    CourseId = 4,
                    Name = "White",
                    Rating = 70.0m,
                    Slope = 122
                },
                new()
                {
                    TeeBoxId = 16,
                    CourseId = 4,
                    Name = "Yellow",
                    Rating = 67.7m,
                    Slope = 119
                },
                new()
                {
                    TeeBoxId = 17,
                    CourseId = 5,
                    Name = "Black",
                    Rating = 73.9m,
                    Slope = 132
                },
                new()
                {
                    TeeBoxId = 18,
                    CourseId = 5,
                    Name = "Blue",
                    Rating = 71.8m,
                    Slope = 126
                },
                new()
                {
                    TeeBoxId = 19,
                    CourseId = 5,
                    Name = "White",
                    Rating = 69.2m,
                    Slope = 121
                },
                new()
                {
                    TeeBoxId = 20,
                    CourseId = 5,
                    Name = "Gold",
                    Rating = 66.9m,
                    Slope = 118
                }
            };

            return teeBoxes;
        }
    }
}
