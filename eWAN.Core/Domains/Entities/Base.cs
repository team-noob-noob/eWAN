using System;

namespace eWAN.Core.Domains.Entities.Base
{
    ///<summary>Common properties for all Entity</summary>
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateTime now = DateTime.Now;

            Id = Guid.NewGuid();
            createdAt = now;
            updatedAt = now;
            deletedAt = null;
        }

        public Guid Id;

        ///<summary>Indicates when the instance was created</summary>
        public DateTime createdAt;
        
        ///<summary>Indicates if the instance is updated</summary>
        public DateTime updatedAt;

        ///<summary>Indicates if the instance is deleted. If null, the value is not deleted.</summary>
        public DateTime? deletedAt;
    }
}