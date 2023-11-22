using Microsoft.EntityFrameworkCore;
using Zimaltec.DataAccess;

namespace Zimaltec.Web
{
    /// <summary>
    /// Extensions for Program services.
    /// </summary>
    public static class ServiceResolver
    {
        /// <summary>
        /// Register services.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddDbContext<ZimaltecDbContext>(opt => 
                opt.UseInMemoryDatabase("ZimaltecTaskList"));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddEndpointsApiExplorer();

            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(policy => 
                    policy.Expire(TimeSpan.FromMinutes(10)));

                // Custome caching policy
                options.AddPolicy("1SecondsCache", policy => 
                    policy.Expire(TimeSpan.FromSeconds(1)));
            });

            services.AddAutoMapper(typeof(Program));

            services.AddSwaggerGen();
        }
    }
}
