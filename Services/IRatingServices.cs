using Entities;

namespace Services
{
    public interface IRatingServices
    {
        Task<Rating> AddRating(Rating rating);
    }
}