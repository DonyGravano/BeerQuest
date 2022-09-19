using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using AutoFixture.NUnit3;
using BeerQuest.Models;
using Dapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;

namespace BeerQuest.CoreDataProvider.UnitTests
{
    [TestFixture]
    public class SqlLiteVenueReviewRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockQueryExecutor = new Mock<IQueryExecutor>();
        }

        private Mock<IQueryExecutor> _mockQueryExecutor;
        private const string BaseQuery =
            "SELECT name, category, url, date, excerpt, thumbnail, lat, lng, address, phone, twitter, stars_beer AS BeerRating, stars_atmosphere AS AtmosphereRating, stars_amenities AS AmenitiesRating, stars_value AS ValueRating, tags AS JoinedTags FROM leedsbeerquest ";

        private SqlLiteVenueReviewRepository Sut => new(_mockQueryExecutor.Object);

        [Test]
        public void Ctor_NullArgument_ThrowsNullArgumentException()
        {
            var fixture = new Fixture();
            var assertion = new GuardClauseAssertion(fixture.Customize(new AutoMoqCustomization()));
            assertion.Verify(typeof(SqlLiteVenueReviewRepository).GetConstructors());
        }

        [Test]
        public async Task GetAllVenueReviewsAsync_CallsQueryExecutor_WithQuery()
        {
            await Sut.GetAllVenueReviewsAsync();

            _mockQueryExecutor.Verify(qe => qe.QueryAsync<VenueReview>(BaseQuery, null), Times.Once);
        }

        [Test]
        [AutoData]
        public async Task GetVenueReviewsDateTimeAsync_CallsQueryExecutor_WithCorrectQuery(DateTime dateTime, ComparisonOperator comparisonOperator)
        {
            var expectedQuery = BaseQuery + $"WHERE date {comparisonOperator.ToOperatorString()} @dateTime";
            await Sut.GetVenueReviewsDateTimeAsync(dateTime, comparisonOperator);

            var parameters = new List<object>();
            _mockQueryExecutor.Verify(qe => qe.QueryAsync<VenueReview>(expectedQuery, Capture.In(parameters)));
            using (new AssertionScope())
            {
                parameters.Should().HaveCount(1);
                parameters.Single().Should().BeEquivalentTo(new {dateTime});
            }
        }

        [Test]
        [AutoData]
        public async Task GetVenueReviewsByRatingAsync_CallsQueryExecutor_WithCorrectQuery(RatingType ratingType, double rating, ComparisonOperator comparisonOperator)
        {
            var expectedQuery = BaseQuery + $"WHERE {ratingType.ToDbColumn()} {comparisonOperator.ToOperatorString()} @rating";
            await Sut.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator);

            var parameters = new List<object>();
            _mockQueryExecutor.Verify(qe => qe.QueryAsync<VenueReview>(expectedQuery, Capture.In(parameters)));
            using (new AssertionScope())
            {
                parameters.Should().HaveCount(1);
                parameters.Single().Should().BeEquivalentTo(new { rating });
            }
        }

        [Test]
        [AutoData]
        public async Task GetVenueReviewsByTagsAsync_WithTags_CallsQueryExecutor_WithCorrectQuery(string[] tags)
        {
            var expectedQuery = BaseQuery + $"WHERE tags LIKE '%' || @param0 || '%' AND tags LIKE '%' || @param1 || '%' AND tags LIKE '%' || @param2 || '%'";
            await Sut.GetVenueReviewsByTagsAsync(tags);

            var parameters = new List<object>();
            _mockQueryExecutor.Verify(qe => qe.QueryAsync<VenueReview>(expectedQuery, Capture.In(parameters)));
            using (new AssertionScope())
            {
                parameters.Should().HaveCount(1);
                var parameter = parameters.Single();
                parameter.Should().Match<DynamicParameters>(dp => dp.ParameterNames.Count() == 3);
                var dynamicParameters = parameter as DynamicParameters;
                dynamicParameters!.Get<string>("param0").Should().Contain(tags[0]);
                dynamicParameters!.Get<string>("param1").Should().Contain(tags[1]);
                dynamicParameters!.Get<string>("param2").Should().Contain(tags[2]);
            }
        }

        [Test]
        public async Task GetVenueReviewsByTagsAsync_NoTags_CallsQueryExecutor_WithCorrectQuery()
        {
            await Sut.GetVenueReviewsByTagsAsync(new List<string>().ToArray());

            _mockQueryExecutor.Verify(qe => qe.QueryAsync<VenueReview>(BaseQuery, null), Times.Once);
        }
    }
}
