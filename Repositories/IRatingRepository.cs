using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> addRatingToDB(Rating rating);
    }
}