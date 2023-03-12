using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Golfville.Gm.Scoring.Data.Extensions
{
    public static class ScoringRepositoryServiceExtension
    {
        public static void AddScoringRepositoryServices(
            this IServiceCollection serviceCollection,            
            string databaseName
        )
        {
            serviceCollection.AddTransient<IMemberScoreRepository, MemberScoreRepository>();
            serviceCollection.AddTransient<IScoringDbContext, ScoringDbContext>();
            serviceCollection.AddTransient<IHandicapService, HandicapService>();
            serviceCollection.AddTransient<ICourseRepository, CourseRepository>();
            serviceCollection.AddDbContext<ScoringDbContext>(option =>
            {
                option.UseInMemoryDatabase(databaseName);
            });
        }
    }
}
