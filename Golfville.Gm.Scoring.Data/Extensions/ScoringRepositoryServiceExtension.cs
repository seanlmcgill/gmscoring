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
            string accountEndpoint,
            string accountKey,
            string databaseName
        )
        {
            serviceCollection.AddTransient<IMemberScoreRepository, MemberScoreRepository>();
            serviceCollection.AddDbContext<IGmDbContext, GmDbContext>(option =>
            {
                option.UseCosmos(accountEndpoint, accountKey, databaseName);
            });
        }
    }
}
