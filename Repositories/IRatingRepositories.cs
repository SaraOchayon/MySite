using Entities;

namespace Repositories
{
    public interface IRatingRepositories
    {
        Task<Rating> AddRating(Rating rating);
    }
}