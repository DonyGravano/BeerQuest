using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerQuest.Application.Interfaces;
using HotChocolate;

namespace BeerQuest.Models.GraphQL
{
    public class PubReviewQuery
    {
        //public async Task<IReadOnlyList<PubReview>> GetPubReviewsByName([Service] IPubReviewService pubReviewService, string name)
        //{
        //    return (await pubReviewService.GetAllPubReviewsAsync()).Where(x =>
        //        string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        //}

        public PubReview GetPubReview =>
            new PubReview
            {
                Name = "Test"
            };
    }
}
