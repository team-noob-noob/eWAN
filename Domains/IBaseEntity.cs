using System;

namespace eWAN.Domains
{
    public interface IBaseEntity
    {
        DateTime createdAt { get; }
        DateTime? updatedAt { get; set; }
        DateTime? deletedAt { get; set; }
        bool isDeleted();
    }
}
