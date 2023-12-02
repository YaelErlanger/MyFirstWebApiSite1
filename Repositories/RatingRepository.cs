using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyStore326659356Context _store326659356Context;
        public RatingRepository(MyStore326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }
        public async Task<Rating> addRatingToDB(Rating rating)
        {
            // await _store326659356Context.Rating
            await _store326659356Context.SaveChangesAsync();


            return rating;
        }
    }
}
