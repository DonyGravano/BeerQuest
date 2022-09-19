using BeerQuest.Application.Interfaces;
using BeerQuest.CoreDataProvider.Interfaces;
using BeerQuest.Models;

namespace BeerQuest.Application;

public class PubReviewService : IPubReviewService
{
    private readonly IPubReviewRepository _pubReviewRepository;

    public PubReviewService(IPubReviewRepository pubReviewRepository)
    {
        _pubReviewRepository = pubReviewRepository ?? throw new ArgumentNullException(nameof(pubReviewRepository));
    }

    public async Task<IReadOnlyList<PubReview>> GetAllPubReviewsAsync()
    {
        return await _pubReviewRepository.GetAllPubReviewsAsync();
    }
}