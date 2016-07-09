using System.Data.Entity.ModelConfiguration;
using TaskBoard.Web.Infrastructure.Domain;

namespace TaskBoard.Web.Infrastructure.DataAccess.Mappings
{
    internal abstract class EntityMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public EntityMapping()
        {
            HasKey(x => x.Id);
        }
    }
}