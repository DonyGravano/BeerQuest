using BeerQuest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeerQuest.Api.Controllers;

[Route("[controller]")]
// I would opt to use the [route] attribute but I prefer my methods to be more verbose
public class PubReviewController : Controller
{
    private readonly IPubReviewService _reviewService;

    public PubReviewController(IPubReviewService reviewService)
    {
        _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllPubReviewsAsync()
    {
        return Ok(await _reviewService.GetAllPubReviewsAsync());
    }
}