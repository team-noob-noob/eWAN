using eWAN.Core.Domains.Entities.Base;

namespace eWAN.Core.Domains.Entities
{
    public class Log : Entity
    {
        public string? EntityName { get; set; }
        public int? EntityId { get; set; }

        public string Action { get; set; }
        public string Details { get; set; }

        public int? UserResponsible_Id { get; set; }
    }
}
