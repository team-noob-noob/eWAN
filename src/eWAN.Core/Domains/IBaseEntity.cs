using System;

namespace eWAN.Core.Domains
{
    public interface IBaseEntity
    {
        Guid Id { get; }

        ///<summary>Indicates when the instance was created</summary>
        DateTime createdAt { get; }
        
        ///<summary>Indicates if the instance is updated</summary>
        DateTime updatedAt { get; }

        ///<summary>Indicates if the instance is deleted. If null, the value is not deleted.</summary>
        DateTime? deletedAt { get; set; }
    }
}
