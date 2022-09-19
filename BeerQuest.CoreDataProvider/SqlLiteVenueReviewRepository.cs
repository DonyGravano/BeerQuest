using System.Data;
using System.Text;
using BeerQuest.CoreDataProvider.Interfaces;
using BeerQuest.Models;
using Dapper;

namespace BeerQuest.CoreDataProvider;

public class SqlLiteVenueReviewRepository : IVenueReviewRepository
{
    private readonly IQueryExecutor _queryExecutor;

    private const string BaseQuery =
        "SELECT name, category, url, date, excerpt, thumbnail, lat, lng, address, phone, twitter, stars_beer AS BeerRating, stars_atmosphere AS AtmosphereRating, stars_amenities AS AmenitiesRating, stars_value AS ValueRating, tags AS JoinedTags FROM leedsbeerquest ";

    public SqlLiteVenueReviewRepository(IQueryExecutor queryExecutor)
    {
        _queryExecutor = queryExecutor ?? throw new ArgumentNullException(nameof(queryExecutor));
    }

    public async Task<IReadOnlyList<VenueReview>> GetAllVenueReviewsAsync()
    {
        return await _queryExecutor.QueryAsync<VenueReview>(BaseQuery);
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsByTagsAsync(string[] tags)
    {
        if (!tags.Any()) return await _queryExecutor.QueryAsync<VenueReview>(BaseQuery);

        var stringBuilder = new StringBuilder(BaseQuery);
        var additionalClauses = new List<string>();
        var dynamicParameters = new DynamicParameters();
        for (var i = 0; i < tags.Length; i++)
        {   
            var sqlKeyword = i == 0 ? "WHERE" : "AND";
            additionalClauses.Add(sqlKeyword + $" tags LIKE '%' || @param{i} || '%'");
            dynamicParameters.Add($"@param{i}", $"{tags[i]}", DbType.AnsiString, ParameterDirection.Input);
        }

        var finalQuery = stringBuilder.AppendJoin(' ', additionalClauses).ToString();
        return await _queryExecutor.QueryAsync<VenueReview>(finalQuery, dynamicParameters);
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsDateTimeAsync(DateTime dateTime, ComparisonOperator comparisonOperator)
    {
        var finalQuery = BaseQuery + $"WHERE date {comparisonOperator.ToOperatorString()} @dateTime";
        return await _queryExecutor.QueryAsync<VenueReview>(finalQuery, new { dateTime });
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsByRatingAsync(RatingType ratingType, double rating, ComparisonOperator comparisonOperator)
    {
        var finalQuery = BaseQuery + $"WHERE {ratingType.ToDbColumn()} {comparisonOperator.ToOperatorString()} @rating";
        return await _queryExecutor.QueryAsync<VenueReview>(finalQuery, new { rating });
    }
}