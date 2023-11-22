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

            services.AddAutoMapper(typeof(Program));

            services.AddSwaggerGen();
        }
    }
}
