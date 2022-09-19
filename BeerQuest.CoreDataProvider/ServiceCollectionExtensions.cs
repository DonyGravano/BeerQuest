using System.Data;
using BeerQuest.CoreDataProvider.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeerQuest.CoreDataProvider;

public static class ServiceCollectionExtensions
{
    public static void AddCoreDataProviders(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddTransient<IConnectionStringConfig, ConnectionStringConfig>();
        serviceCollection.AddTransient<IDbConnection>(sp =>
        {
            var connectionStringConfig = sp.GetRequiredService<IConnectionStringConfig>();
            return new SqliteConnection(connectionStringConfig.ConnectionString);
        });
        serviceCollection.AddTransient<IQueryExecutor, QueryExecutor>();
        serviceCollection.AddTransient<IPubReviewRepository, SqlLitePubReviewRepository>();
    }
}