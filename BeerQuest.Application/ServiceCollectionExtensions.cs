using BeerQuest.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BeerQuest.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IVenueReviewService, VenueReviewService>();
    }
}