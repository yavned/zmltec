using Microsoft.EntityFrameworkCore;
using Zimaltec.Entities.Models;

namespace Zimaltec.DataAccess
{
    public class ZimaltecDbContext : DbContext
    {
        public ZimaltecDbContext(DbContextOptions<ZimaltecDbContext> options)
            : base(options) { }

        public DbSet<ZimaltecTask> ZimaltecTasks => Set<ZimaltecTask>();
    }
}
