using System;

namespace eWAN.Domains
{
    public class BaseEntity
    {
        public DateTime createdAt { get; private set; } = DateTime.Now;
        public DateTime? updatedAt { get; set; } = null;
        public DateTime? deletedAt { get; set; } = null;
        public bool isDeleted() => deletedAt != null;
    }
}
