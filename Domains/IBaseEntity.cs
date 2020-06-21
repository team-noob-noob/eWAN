using System;

namespace eWAN.Domains
{
    public interface IBaseEntity
    {
        public DateTime createdAt { get; }
        public DateTime? updatedAt { get; }
        public DateTime? deletedAt { get; }
    }
}
