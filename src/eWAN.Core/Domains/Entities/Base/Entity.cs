using System;

namespace eWAN.Core.Domains.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
    }
}
