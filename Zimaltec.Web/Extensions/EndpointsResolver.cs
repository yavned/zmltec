using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
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

            app.MapGet("/tasks/done", async (ZimaltecDbContext db) =>
                await db.ZimaltecTasks.Where(t => t.IsDone).ToListAsync())
                .CacheOutput("10SecondsCache");

            app.MapGet("/tasks/{id}", async (int id, ZimaltecDbContext db) =>
                await db.ZimaltecTasks.FindAsync(id)
                    is ZimaltecTask tsk
                        ? Results.Ok(tsk)
                        : Results.NotFound());

            // Insert
            app.MapPost("/task", async (IMapper _mapper, InsertZimaltecTaskDTO inputTask, ZimaltecDbContext db) =>
            {
                var newTask = _mapper.Map<ZimaltecTask>(inputTask);

                db.ZimaltecTasks.Add(newTask);
                await db.SaveChangesAsync();

                return Results.Created($"/tasks/{newTask.Id}", newTask);
            });

            // Update
            app.MapPut("/task/{id}", async (int id, UpdateZimaltecTaskDTO inputTask, ZimaltecDbContext db) =>
            {
                var existingTask = await db.ZimaltecTasks.FindAsync(id);

                if (existingTask is null) 
                    return Results.NotFound();

                existingTask.Name = inputTask.Name;
                existingTask.IsDone = inputTask.IsDone;
                existingTask.OrderNum = inputTask.OrderNum;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            // Delete
            app.MapDelete("/task/{id}", async (int id, ZimaltecDbContext db) =>
            {
                var existingTask = await db.ZimaltecTasks.FindAsync(id);

                if (existingTask is null)
                    return Results.NotFound();

                db.ZimaltecTasks.Remove(existingTask);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}