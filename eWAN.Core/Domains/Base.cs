using System;

namespace eWAN.Core.Domains.Base
{
    ///<summary>Common properties for all Entity</summary>
    public class BaseEntity
    {
        public BaseEntity()
        {
            DateTime now = DateTime.Now;

            createdAt = now;
            updatedAt = now;
            deletedAt = null;
        }

        public int Id;
        public DateTime createdAt;
        public DateTime updatedAt;
        public DateTime deletedAt;
    }
}