using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zimaltec.Business.Models;
using Zimaltec.DataAccess;
using Zimaltec.Entities.Models;

namespace Zimaltec.Web
{
    /// <summary>
    /// Extensions for registering application endpoints.
    /// </summary>
    public static class EndpointsResolver
    {
        /// <summary>
        /// Register application endpoints.
        /// </summary>
        /// <param name="app"><see cref="IEndpointRouteBuilder"/></param>
        public static void AddAppEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/tasks", async (ZimaltecDbContext db) => await db.ZimaltecTasks.ToListAsync())
                .CacheOutput();

            app.MapPost("/task", async (IMapper _mapper, InsertZimaltecTaskDTO tsk, ZimaltecDbContext db) =>
            {
                var newTask = _mapper.Map<ZimaltecTask>(tsk);

                db.ZimaltecTasks.Add(newTask);
                await db.SaveChangesAsync();

                return Results.Created($"/tasks/{newTask.Id}", newTask);
            });
        }
    }
}