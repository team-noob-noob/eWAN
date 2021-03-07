using System;

namespace Sinuka.Core.Domains.Entities.Base
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
