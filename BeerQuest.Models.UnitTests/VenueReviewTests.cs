using System.Text.Json.Serialization;
using AutoFixture.NUnit3;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace BeerQuest.Models.UnitTests;

[TestFixture]
public class VenueReviewTests
{
    [Test]
    [AutoData]
    public void Tags_Got_SplitsTheConcatenatedString(string[] randomStrings)
    {
        var sut = new VenueReview
        {
            JoinedTags = string.Join(',', randomStrings)
        };

        using (new AssertionScope())
        {
            sut.Tags.Should().HaveCount(randomStrings.Length);
            sut.Tags.Should().BeEquivalentTo(randomStrings);
        }
    }

    [Test]
    [AutoData]
    public void JoinedTags_HasJsonIgnoreAttribute(string[] randomStrings)
    {
        var properties = typeof(VenueReview).Properties().ThatAreDecoratedWith<JsonIgnoreAttribute>().ToArray();
        using (new AssertionScope())
        {
            properties.Should().HaveCount(1);
            properties[0].Name.Should().Be(nameof(VenueReview.JoinedTags));
        }
    }
}