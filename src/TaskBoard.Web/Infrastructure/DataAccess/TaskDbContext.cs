using System.Data.Entity;
using TaskBoard.Web.Infrastructure.Domain;

namespace TaskBoard.Web.Infrastructure.DataAccess
{
    internal sealed class TaskDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        public DbSet<User> Users { get; set; }
    }
}