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
                var courseId = random.Next() % 6;
                var teeBoxId = random.Next() % 4;
                var score = random.Next(70, 91);
                seedScores.Add(
                    new MemberScore
                    {
                        Id = i + 1,
                        MemberId = memberId,
                        CourseId = courseId,
                        TeeBoxId = teeBoxId,
                        Score = score,
                        PostingDateTime = baseDate + new TimeSpan(i + 2, postTimeHours, 0, 0)
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
                    Id = 1,
                    Name = "TPC Sawgrass",
                    Address = "110 Championship Way, Ponte Vedra Beach, FL 32082",
                    TeeList = new List<Tee>()
                    {
                        new()
                        {
                            Id = 1,
                            Description = "The Players",
                            Rating = 76.8,
                            Slope = 155
                        },
                        new()
                        {
                            Id = 2,
                            Description = "Blue",
                            Rating = 73.9,
                            Slope = 148
                        },
                        new()
                        {
                            Id = 3,
                            Description = "White",
                            Rating = 70.8,
                            Slope = 138
                        },
                        new()
                        {
                            Id = 4,
                            Description = "Green",
                            Rating = 65.8,
                            Slope = 116
                        }
                    }
                },
                new()
                {
                    Id = 2,
                    Name = "Lederach",
                    Address = "900 Clubhouse Dr, Harleysville, PA 19438",
                    TeeList = new List<Tee>()
                    {
                        new()
                        {
                            Id = 1,
                            Description = "Black",
                            Rating = 73.9,
                            Slope = 137
                        },
                        new()
                        {
                            Id = 2,
                            Description = "Blue",
                            Rating = 71.8,
                            Slope = 134
                        },
                        new()
                        {
                            Id = 3,
                            Description = "Green",
                            Rating = 69.8,
                            Slope = 134
                        },
                        new()
                        {
                            Id = 4,
                            Description = "White",
                            Rating = 64.3,
                            Slope = 131
                        }
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "Scotland Run",
                    Address = "2626 Fries Mill Rd, Williamstown, NJ 08094",
                    TeeList = new List<Tee>()
                    {
                        new()
                        {
                            Id = 1,
                            Description = "Black",
                            Rating = 73.2,
                            Slope = 136
                        },
                        new()
                        {
                            Id = 2,
                            Description = "Blue",
                            Rating = 71.8,
                            Slope = 133
                        },
                        new()
                        {
                            Id = 3,
                            Description = "Green",
                            Rating = 70.9,
                            Slope = 128
                        },
                        new()
                        {
                            Id = 4,
                            Description = "White",
                            Rating = 67.4,
                            Slope = 118
                        }
                    }
                },
                new()
                {
                    Id = 4,
                    Name = "Twisted Dune Golf Club",
                    Address = "2101 Ocean Heights Ave, Egg Harbor Township, NJ 08234",
                    TeeList = new List<Tee>()
                    {
                        new()
                        {
                            Id = 1,
                            Description = "Black",
                            Rating = 74.9,
                            Slope = 130
                        },
                        new()
                        {
                            Id = 2,
                            Description = "Blue",
                            Rating = 72.1,
                            Slope = 126
                        },
                        new()
                        {
                            Id = 3,
                            Description = "White",
                            Rating = 70.0,
                            Slope = 122
                        },
                        new()
                        {
                            Id = 4,
                            Description = "Yellow",
                            Rating = 67.7,
                            Slope = 119
                        }
                    }
                },
                new()
                {
                    Id = 5,
                    Name = "Makefield Highlands Golf Club",
                    Address = "1418 Woodside Rd, Yardley, PA 19067",
                    TeeList = new List<Tee>()
                    {
                        new()
                        {
                            Id = 1,
                            Description = "Black",
                            Rating = 73.9,
                            Slope = 132
                        },
                        new()
                        {
                            Id = 2,
                            Description = "Blue",
                            Rating = 71.8,
                            Slope = 126
                        },
                        new()
                        {
                            Id = 3,
                            Description = "White",
                            Rating = 69.2,
                            Slope = 121
                        },
                        new()
                        {
                            Id = 4,
                            Description = "Gold",
                            Rating = 66.9,
                            Slope = 118
                        }
                    }
                }
            };

            return courseList.ToArray();
        }
    }
}
