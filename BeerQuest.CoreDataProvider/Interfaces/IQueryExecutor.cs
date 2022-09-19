namespace BeerQuest.CoreDataProvider;

public interface IQueryExecutor
{
    Task<IReadOnlyList<TResult>> QueryAsync<TResult>(string query, object? parameters = null);

    Task<int> ExecuteAsync(string sql, object? parameters = null);
}