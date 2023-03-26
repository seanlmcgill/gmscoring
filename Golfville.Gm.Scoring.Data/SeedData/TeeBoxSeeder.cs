using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.SeedData
{
    internal class TeeBoxSeeder
    {
        public static List<TeeBox> Get()
        {
            return new List<TeeBox>()
            {
                new()
                {
                    TeeBoxId = 1,
                    CourseId = 1,
                    TeeColor = TeeColor.Black,
                    Name = "The Players",
                    Rating = 76.8m,
                    Slope = 155
                },
                new()
                {
                    TeeBoxId = 2,
                    CourseId = 1,
                    TeeColor = TeeColor.Blue,
                    Name = "Championship",
                    Rating = 73.9m,
                    Slope = 148
                },
                new()
                {
                    TeeBoxId = 3,
                    CourseId = 1,
                    TeeColor = TeeColor.White,
                    Name = "Mens",
                    Rating = 70.8m,
                    Slope = 138
                },
                new()
                {
                    TeeBoxId = 4,
                    CourseId = 1,
                    TeeColor = TeeColor.Green,
                    Name = "Senior",
                    Rating = 65.8m,
                    Slope = 116
                },
                new()
                {
                    TeeBoxId = 5,
                    CourseId = 2,
                    TeeColor = TeeColor.Black,
                    Name = "Championship",
                    Rating = 73.9m,
                    Slope = 137
                },
                new()
                {
                    TeeBoxId = 6,
                    CourseId = 2,
                    TeeColor = TeeColor.Blue,
                    Name = "Members",
                    Rating = 71.8m,
                    Slope = 134
                },
                new()
                {
                    TeeBoxId = 7,
                    CourseId = 2,
                    TeeColor = TeeColor.Green,
                    Name = "Mens",
                    Rating = 69.8m,
                    Slope = 134
                },
                new()
                {
                    TeeBoxId = 8,
                    CourseId = 2,
                    TeeColor = TeeColor.White,
                    Name = "Mens",
                    Rating = 64.3m,
                    Slope = 131
                },
                new()
                {
                    TeeBoxId = 9,
                    CourseId = 3,
                    TeeColor = TeeColor.Black,
                    Name = "Championship",
                    Rating = 73.2m,
                    Slope = 136
                },
                new()
                {
                    TeeBoxId = 10,
                    CourseId = 3,
                    TeeColor = TeeColor.Blue,
                    Name = "Members",
                    Rating = 71.8m,
                    Slope = 133
                },
                new()
                {
                    TeeBoxId = 11,
                    CourseId = 3,
                    TeeColor = TeeColor.Green,
                    Name = "Mens",
                    Rating = 70.9m,
                    Slope = 128
                },
                new()
                {
                    TeeBoxId = 12,
                    CourseId = 3,
                    TeeColor = TeeColor.White,
                    Name = "Senior",
                    Rating = 67.4m,
                    Slope = 118
                },
                new()
                {
                    TeeBoxId = 13,
                    CourseId = 4,
                    TeeColor = TeeColor.Black,
                    Name = "Championship",
                    Rating = 74.9m,
                    Slope = 130
                },
                new()
                {
                    TeeBoxId = 14,
                    CourseId = 4,
                    TeeColor = TeeColor.Blue,
                    Name = "Members",
                    Rating = 72.1m,
                    Slope = 126
                },
                new()
                {
                    TeeBoxId = 15,
                    CourseId = 4,
                    TeeColor = TeeColor.White,
                    Name = "Mens",
                    Rating = 70.0m,
                    Slope = 122
                },
                new()
                {
                    TeeBoxId = 16,
                    CourseId = 4,
                    TeeColor = TeeColor.Yellow,
                    Name = "Senior",
                    Rating = 67.7m,
                    Slope = 119
                },
                new()
                {
                    TeeBoxId = 17,
                    CourseId = 5,
                    TeeColor = TeeColor.Black,
                    Name = "Championship",
                    Rating = 73.9m,
                    Slope = 132
                },
                new()
                {
                    TeeBoxId = 18,
                    CourseId = 5,
                    TeeColor = TeeColor.Blue,
                    Name = "Member",
                    Rating = 71.8m,
                    Slope = 126
                },
                new()
                {
                    TeeBoxId = 19,
                    CourseId = 5,
                    TeeColor = TeeColor.White,
                    Name = "Mens",
                    Rating = 69.2m,
                    Slope = 121
                },
                new()
                {
                    TeeBoxId = 20,
                    CourseId = 5,
                    TeeColor = TeeColor.Gold,
                    Name = "Senior",
                    Rating = 66.9m,
                    Slope = 118
                }
            };
        }
    }
}
