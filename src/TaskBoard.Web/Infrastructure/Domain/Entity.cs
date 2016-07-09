using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; }
    }
}