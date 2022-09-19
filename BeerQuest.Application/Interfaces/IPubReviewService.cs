using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerQuest.Models;

namespace BeerQuest.Application.Interfaces
{
    public interface IPubReviewService
    {
        public Task<IReadOnlyList<PubReview>> GetAllPubReviewsAsync();
    }
}
