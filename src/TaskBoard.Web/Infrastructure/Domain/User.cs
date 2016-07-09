using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
    }
}