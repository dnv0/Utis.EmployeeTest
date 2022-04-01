using Microsoft.EntityFrameworkCore;
using WorkerAPI.Models;

namespace WorkerAPI.Infrastructure
{
    public class WorkerContext : DbContext
    {
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {

        }

        public DbSet<Models.Worker> Workers { get; set; }
    }
}
