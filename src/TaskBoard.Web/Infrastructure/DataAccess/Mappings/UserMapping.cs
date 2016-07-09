using TaskBoard.Web.Infrastructure.Domain;

namespace TaskBoard.Web.Infrastructure.DataAccess.Mappings
{
    internal sealed class UserMapping : EntityMapping<User>
    {
        public UserMapping()
        {
            Property(x => x.Name).IsRequired();
            Property(x => x.Login).IsRequired();
            Property(x => x.PasswordHash).IsRequired();
            Property(x => x.PasswordSalt).IsRequired();
        }
    }
}