using BeerQuest.Models;

namespace BeerQuest.CoreDataProvider.Interfaces;

public interface IVenueReviewRepository
{
    public Task<IReadOnlyList<VenueReview>> GetAllVenueReviewsAsync();
    Task<IReadOnlyList<VenueReview>> GetVenueReviewsByTagsAsync(string[] tags);

    public Task<IReadOnlyList<VenueReview>> GetVenueReviewsDateTimeAsync(DateTime dateTime,
        ComparisonOperator comparisonOperator);

    public Task<IReadOnlyList<VenueReview>> GetVenueReviewsByRatingAsync(RatingType ratingType, double rating,
        ComparisonOperator comparisonOperator);
}