using System;
using eWAN.Core.Domains.Entities.Base;

namespace eWAN.Core.Domains.Entities
{
    public class Attachment : Entity
    {
        public Guid StorageId { get; set; }
        public string OriginalFileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] Binary { get; set; }
    }
}
