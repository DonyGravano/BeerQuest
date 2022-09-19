using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace BeerQuest.Models.UnitTests
{
    [TestFixture]
    public class ExtensionTests
    {
        [TestCase(RatingType.Null, "")]
        [TestCase(RatingType.Beer, "stars_beer")]
        [TestCase(RatingType.Atmosphere, "stars_atmosphere")]
        [TestCase(RatingType.Amenities, "stars_amenities")]
        [TestCase(RatingType.Value, "stars_value")]
        public void RatingType_ToDbColumn_ReturnsCorrectValue(RatingType ratingType, string expectedDbColumn)
        {
            var result = ratingType.ToDbColumn();

            result.Should().Be(expectedDbColumn);
        }

        [Test]
        public void RatingType_ToDbColumn_Default_UsesNullAndReturnsEmptyString()
        {
            var result = ((RatingType)default).ToDbColumn();

            result.Should().BeEmpty();
        }

        [TestCase(ComparisonOperator.NotEqual, "<>")]
        [TestCase(ComparisonOperator.Equal, "=")]
        [TestCase(ComparisonOperator.GreaterThan, ">")]
        [TestCase(ComparisonOperator.GreaterThanOrEqualTo, ">=")]
        [TestCase(ComparisonOperator.LessThan, "<")]
        [TestCase(ComparisonOperator.LessThanOrEqualTo, "<=")]
        public void ComparisonOperator_ToOperatorString_ReturnsCorrectValue(ComparisonOperator comparisonOperator, string expected)
        {
            var result = comparisonOperator.ToOperatorString();

            result.Should().Be(expected);
        }

        [Test]
        public void ComparisonOperator_ToOperatorString_Default_UsesNotEqual()
        {
            var result = ((ComparisonOperator)default).ToOperatorString();

            result.Should().Be("<>");
        }
    }
}
