using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyStore326659356Context _store326659356Context;
        private readonly IConfiguration _configuration;
        public RatingRepository(MyStore326659356Context store326659356Context, IConfiguration configuration)
        {
            _store326659356Context = store326659356Context;
            _configuration = configuration;
        }
        public async Task<Rating> addRatingToDB(Rating rating) 
        {

            //_store326659356Context.Ratings.Add(rating);
            //  await _store326659356Context.SaveChangesAsync();

            string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER, USER_AGENT, Record_Date)" +
                "VALUES (@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";

            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("School")))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NVarChar, 10).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 100).Value = rating.Referer;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 500).Value = rating.UserAgent;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return rating;
            }  
        }
    }
}
