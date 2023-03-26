using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.SeedData
{
    internal class CourseSeeder
    {
        public static List<Course> Get()
        {
            return new List<Course>()
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
        }
    }
}
