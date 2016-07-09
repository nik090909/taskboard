using System.Data.Entity;

namespace TaskBoard.Web.Infrastructure.DataAccess
{
    internal sealed class TaskDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly); 
        }
    }
}