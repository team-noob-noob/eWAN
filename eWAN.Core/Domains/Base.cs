using System;

namespace eWAN.Core.Domains.Base
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
        public DateTime createdAt;
        public DateTime updatedAt;
        public DateTime deletedAt;
    }
}