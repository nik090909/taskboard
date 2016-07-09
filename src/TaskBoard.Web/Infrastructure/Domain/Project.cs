using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public class Project : Entity
    {
        public string Name { get; set; }

        public User CreatedBy { get; set; }
    }
}