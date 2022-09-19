using BeerQuest.Models;

namespace BeerQuest.Application.Interfaces;

public interface IVenueReviewService
{
    public Task<IReadOnlyList<VenueReview>> GetAllVenueReviewsAsync();

    public Task<IReadOnlyList<VenueReview>> GetVenueReviewsByTagsAsync(string[] tags);

    public Task<IReadOnlyList<VenueReview>> GetVenueReviewsWithDateTimeAsync(DateTime dateTime,
        ComparisonOperator comparisonOperator);

    public Task<IReadOnlyList<VenueReview>> GetVenueReviewsByRatingAsync(RatingType ratingType, double rating,
        ComparisonOperator comparisonOperator);
}