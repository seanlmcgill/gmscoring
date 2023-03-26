using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Repositories;
using Golfville.Gm.Scoring.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Golfville.Gm.Scoring.Data.Extensions
{
    public static class ScoringRepositoryServiceExtension
    {
        public static void AddScoringRepositoryServices(
            this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder> optionsAction
        )
        {
            serviceCollection.AddDbContext<GmDbContext>(optionsAction);
            serviceCollection.AddTransient<IMemberScoreRepository, MemberScoreRepository>();
            serviceCollection.AddTransient<IHandicapService, HandicapService>();
            serviceCollection.AddTransient<ICourseRepository, CourseRepository>();
            serviceCollection.AddTransient<ITeeBoxRepository, TeeBoxRepository>();
        }
    }
}
