using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerQuest.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BeerQuest.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IVenueReviewService, VenueReviewService>();
        }
    }
}
