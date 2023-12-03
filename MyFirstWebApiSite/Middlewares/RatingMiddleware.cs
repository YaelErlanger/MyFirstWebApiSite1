using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Entities;
using Services;

namespace MyFirstWebApiSite.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
     
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Console.WriteLine("mmmm");
            Rating rating = new Rating();
             await _next(httpContext);

            DateTime date = DateTime.Now;
            rating.Host = httpContext.Request.Host.ToString();
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Headers["Referer"].ToString();
            rating.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            rating.RecordDate = date;
            await ratingService.addRatingToDB(rating);
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
