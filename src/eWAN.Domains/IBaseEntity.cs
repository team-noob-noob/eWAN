using System;

namespace eWAN.Domains
{
    public interface IBaseEntity
    {
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        bool IsDeleted();
    }
}
