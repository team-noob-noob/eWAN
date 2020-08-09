using System;

namespace eWAN.Domains
{
    public class BaseEntity : IBaseEntity
    {
        public virtual DateTime createdAt { get; protected set; } = DateTime.Now;
        public virtual DateTime? updatedAt { get; set; } = null;
        public virtual DateTime? deletedAt { get; set; } = null;
        public bool isDeleted() => deletedAt != null;
    }
}
