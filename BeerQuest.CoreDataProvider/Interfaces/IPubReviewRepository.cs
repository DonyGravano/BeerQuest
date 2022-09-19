using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerQuest.Models;

namespace BeerQuest.CoreDataProvider.Interfaces
{
    public interface IPubReviewRepository
    {
        public Task<IReadOnlyList<PubReview>> GetAllPubReviewsAsync();
    }
}
