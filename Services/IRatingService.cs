using Entities;

namespace Services
{
    public interface IRatingService
    {
        Task<Rating> addRatingToDB(Rating rating);
    }
}