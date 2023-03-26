using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.SeedData
{
    internal class MemberSeeder
    {
        public static List<Member> Get()
        {
            return new List<Member>
            {
                new()
                {
                        MemberId = 1,
                        FirstName = "Bob",
                        LastName = "Crusher",
                        EmailAddress = "bcrush@golfville.com",
                        DateOfBirth = new DateTime(1990, 6, 1)
                },
                new()
                {
                        MemberId = 2,
                        FirstName = "Sally",
                        LastName = "Puttsalot",
                        EmailAddress = "sputts@golfville.com",
                        DateOfBirth = new DateTime(2001, 2, 20)
                },
                new()
                {
                        MemberId = 3,
                        FirstName = "Jeff",
                        LastName = "Shanker",
                        EmailAddress = "jshanker@golfville.com",
                        DateOfBirth = new DateTime(1968, 10, 1)
                },
                new()
                {
                        MemberId = 4,
                        FirstName = "Jack",
                        LastName = "Caddy",
                        EmailAddress = "jcaddy@golfville.com",
                        DateOfBirth = new DateTime(2008, 3, 12)
                },
                new()
                {
                        MemberId = 5,
                        FirstName = "Susy",
                        LastName = "Ace",
                        EmailAddress = "sace@golfville.com",
                        DateOfBirth = new DateTime(2004, 7, 29)
                }
            };
        }
    }
}
