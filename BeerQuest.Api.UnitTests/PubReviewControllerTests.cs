using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using BeerQuest.Api.Controllers;
using BeerQuest.Application.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using NUnit.Framework;

namespace BeerQuest.Api.UnitTests
{
    [TestFixture]
    public class PubReviewControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockPubReviewService = new Mock<IPubReviewService>();
        }

        private Mock<IPubReviewService> _mockPubReviewService;

        private PubReviewController Sut => new(_mockPubReviewService.Object);

        // This test checks the constructors parameters all have guard clauses
        [Test]
        public void Ctor_NullArgument_ThrowsNullArgumentException()
        {
            var fixture = new Fixture();
            var assertion = new GuardClauseAssertion(fixture.Customize(new AutoMoqCustomization()));
            assertion.Verify(typeof(PubReviewController).GetConstructors());
        }

        [Test]
        public void Methods_AllHaveRouteAttribute()
        {
            typeof(PubReviewController).Methods().Should().BeDecoratedWith<RouteAttribute>();
        }

        [Test]
        public void Methods_AllHaveAtLeastOneProducesResponseCodeAttribute()
        {
            typeof(PubReviewController).Methods().Should().BeDecoratedWith<ProducesResponseTypeAttribute>();
        }

        [Test]
        public void Methods_AllHaveHttpMethod()
        {
            typeof(PubReviewController).Methods().Should().BeDecoratedWith<HttpMethodAttribute>();
        }
    }
}
