using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using AutoFixture.NUnit3;
using BeerQuest.CoreDataProvider.Interfaces;
using BeerQuest.Models;
using Moq;
using NUnit.Framework;

namespace BeerQuest.Application.UnitTests;

[TestFixture]
public class VenueReviewServiceTests
{
    [SetUp]
    public void SetUp()
    {
        _mockDataRepository = new Mock<IVenueReviewRepository>();
    }

    private Mock<IVenueReviewRepository> _mockDataRepository;

    private VenueReviewService Sut => new(_mockDataRepository.Object);

    [Test]
    public void Ctor_NullArgument_ThrowsNullArgumentException()
    {
        var fixture = new Fixture();
        var assertion = new GuardClauseAssertion(fixture.Customize(new AutoMoqCustomization()));
        assertion.Verify(typeof(VenueReviewService).GetConstructors());
    }

    [Test]
    public async Task GetAllPubReviewsAsync_CallsApplicationService_WithParams()
    {
        await Sut.GetAllVenueReviewsAsync();

        _mockDataRepository.Verify(prs => prs.GetAllVenueReviewsAsync(), Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsByTags_CallsApplicationService_WithParams(string[] tags)
    {
        await Sut.GetVenueReviewsByTagsAsync(tags);

        _mockDataRepository.Verify(prs => prs.GetVenueReviewsByTagsAsync(tags), Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsFromCertainDate_CallsApplicationService_WithParams(DateTime dateTime,
        ComparisonOperator comparisonOperator)
    {
        await Sut.GetVenueReviewsWithDateTimeAsync(dateTime, comparisonOperator);

        _mockDataRepository.Verify(prs => prs.GetVenueReviewsDateTimeAsync(dateTime, comparisonOperator), Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsByRating_CallsApplicationService_WithParams(RatingType ratingType, double rating,
        ComparisonOperator comparisonOperator)
    {
        await Sut.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator);

        _mockDataRepository.Verify(prs => prs.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator),
            Times.Once);
    }
}