using System;

namespace TaskBoard.Web.Infrastructure.Domain
{
    public class Entry : Entity
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}