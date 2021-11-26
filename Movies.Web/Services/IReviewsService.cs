using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Services
{
    public interface IReviewsService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsAsync(string subject);

        Task<ReviewDto> GetReviewAsync(int id);
    }
}
