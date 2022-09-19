using BeerQuest.Application.Interfaces;
using BeerQuest.CoreDataProvider.Interfaces;
using BeerQuest.Models;

namespace BeerQuest.Application;

public class VenueReviewService : IVenueReviewService
{
    private readonly IVenueReviewRepository _venueReviewRepository;

    public VenueReviewService(IVenueReviewRepository venueReviewRepository)
    {
        _venueReviewRepository =
            venueReviewRepository ?? throw new ArgumentNullException(nameof(venueReviewRepository));
    }

    public async Task<IReadOnlyList<VenueReview>> GetAllVenueReviewsAsync()
    {
        return await _venueReviewRepository.GetAllVenueReviewsAsync();
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsByTagsAsync(string[] tags)
    {
        return await _venueReviewRepository.GetVenueReviewsByTagsAsync(tags);
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsWithDateTimeAsync(DateTime dateTime,
        ComparisonOperator comparisonOperator)
    {
        return await _venueReviewRepository.GetVenueReviewsDateTimeAsync(dateTime, comparisonOperator);
    }

    public async Task<IReadOnlyList<VenueReview>> GetVenueReviewsByRatingAsync(RatingType ratingType, double rating,
        ComparisonOperator comparisonOperator)
    {
        return await _venueReviewRepository.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator);
    }
}