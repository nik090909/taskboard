using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public class Block : Entity
    {
        public virtual string Name { get; set; }
        public virtual int Order { get; set; }
    }
}