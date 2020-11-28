using System;

namespace eWAN.Domains
{
    public interface IBaseEntity
    {
        int Id { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        bool IsDeleted();
    }
}
