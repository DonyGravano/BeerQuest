using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using AutoFixture.NUnit3;
using BeerQuest.Api.Controllers;
using BeerQuest.Application.Interfaces;
using BeerQuest.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using NUnit.Framework;

namespace BeerQuest.Api.UnitTests;

[TestFixture]
public class VenueReviewControllerTests
{
    [SetUp]
    public void SetUp()
    {
        _mockReviewService = new Mock<IVenueReviewService>();
    }

    private Mock<IVenueReviewService> _mockReviewService;

    private VenueReviewController Sut => new(_mockReviewService.Object);

    // This test checks the constructors parameters all have guard clauses
    [Test]
    public void Ctor_NullArgument_ThrowsNullArgumentException()
    {
        var fixture = new Fixture();
        var assertion = new GuardClauseAssertion(fixture.Customize(new AutoMoqCustomization()));
        assertion.Verify(typeof(VenueReviewController).GetConstructors());
    }

    [Test]
    public void Methods_AllHaveAtLeastOneProducesResponseCodeAttribute()
    {
        typeof(VenueReviewController).Methods().Should().BeDecoratedWith<ProducesResponseTypeAttribute>();
    }

    [Test]
    public void Methods_AllHaveHttpMethod()
    {
        typeof(VenueReviewController).Methods().Should().BeDecoratedWith<HttpMethodAttribute>();
    }

    [Test]
    public async Task GetAllPubReviewsAsync_CallsApplicationService_WithParams()
    {
        await Sut.GetAllPubReviewsAsync();

        _mockReviewService.Verify(prs => prs.GetAllVenueReviewsAsync(), Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsByTags_CallsApplicationService_WithParams(string[] tags)
    {
        await Sut.GetVenueReviewsByTags(tags);

        _mockReviewService.Verify(prs => prs.GetVenueReviewsByTagsAsync(tags), Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsFromCertainDate_CallsApplicationService_WithParams(DateTime dateTime,
        ComparisonOperator comparisonOperator)
    {
        await Sut.GetVenueReviewsWithDateTimeAsync(dateTime, comparisonOperator);

        _mockReviewService.Verify(prs => prs.GetVenueReviewsWithDateTimeAsync(dateTime, comparisonOperator),
            Times.Once);
    }

    [Test]
    [AutoData]
    public async Task GetVenueReviewsByRating_CallsApplicationService_WithParams(RatingType ratingType, double rating,
        ComparisonOperator comparisonOperator)
    {
        await Sut.GetVenueReviewsByRating(ratingType, rating, comparisonOperator);

        _mockReviewService.Verify(prs => prs.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator),
            Times.Once);
    }
}