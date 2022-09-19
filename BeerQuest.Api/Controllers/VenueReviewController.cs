using BeerQuest.Application.Interfaces;
using BeerQuest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerQuest.Api.Controllers;

[Route("[controller]")]
// I would opt to use the [route] attribute but I prefer my methods to be verbose
public class VenueReviewController : Controller
{
    private readonly IVenueReviewService _reviewService;

    public VenueReviewController(IVenueReviewService reviewService)
    {
        _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllPubReviewsAsync()
    {
        return Ok(await _reviewService.GetAllVenueReviewsAsync());
    }
    
    [HttpGet]
    [Route("tags")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetVenueReviewsByTags([FromQuery] string[] tags)
    {
        return Ok(await _reviewService.GetVenueReviewsByTagsAsync(tags));
    }

    [HttpGet]
    [Route("{dateTime:datetime}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetVenueReviewsWithDateTimeAsync([FromRoute] DateTime dateTime, [FromQuery] ComparisonOperator comparisonOperator)
    {
        return Ok(await _reviewService.GetVenueReviewsWithDateTimeAsync(dateTime, comparisonOperator));
    }

    [HttpGet]
    [Route("{ratingType}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetVenueReviewsByRating([FromRoute] RatingType ratingType, [FromQuery] double rating, [FromQuery] ComparisonOperator comparisonOperator)
    {
        return Ok(await _reviewService.GetVenueReviewsByRatingAsync(ratingType, rating, comparisonOperator));
    }
}