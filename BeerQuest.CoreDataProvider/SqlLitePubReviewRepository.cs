using BeerQuest.CoreDataProvider.Interfaces;
using BeerQuest.Models;

namespace BeerQuest.CoreDataProvider;

public class SqlLitePubReviewRepository : IPubReviewRepository
{
    private readonly IQueryExecutor _queryExecutor;

    public SqlLitePubReviewRepository(IQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));
    }

    public async Task<IReadOnlyList<PubReview>> GetAllPubReviewsAsync()
    {
        return await _queryExecutor.QueryAsync<PubReview>(
            "SELECT name, category, url, date, excerpt, thumbnail, lat, lng, address, phone, twitter, stars_beer AS BeerRating, stars_atmosphere AS AtmosphereRating, stars_amenities AS AmenitiesRating, stars_value AS ValueRating, tags AS JoinedTags FROM leedsbeerquest;");
    }
}