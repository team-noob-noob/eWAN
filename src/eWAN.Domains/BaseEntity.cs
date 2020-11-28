using System;

namespace eWAN.Domains
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public virtual DateTime? UpdatedAt { get; set; } = null;
        public virtual DateTime? DeletedAt { get; set; } = null;
        public bool IsDeleted() => DeletedAt != null;
    }
}
