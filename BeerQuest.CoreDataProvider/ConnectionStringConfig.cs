using Microsoft.Extensions.Configuration;

namespace BeerQuest.CoreDataProvider;

public class ConnectionStringConfig : IConnectionStringConfig
{
    public ConnectionStringConfig(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("BeerQuestDb");
    }

    public string ConnectionString { get; set; }
}