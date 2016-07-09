using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public class EntityLog : Entity
    {
        public virtual Entity Entity { get; set; }
    }
}