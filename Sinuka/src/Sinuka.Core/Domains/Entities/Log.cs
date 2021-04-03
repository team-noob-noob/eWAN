using System;

namespace Sinuka.Core.Domains.Entities
{
    public class Log : Base.IEntity
    {
        long Id { get; set; }

        /// <summary>Describes the action initiated (ex. Login, Registration, Failed2Auth)</summary>
        public string Action { get; set; }

        /// <summary>Optional; additional information on the action</summary>
        public string Description { get; set; }


        /// <summary>Optional; user responsible for starting the action</summary>
        public string Responsible_User_Id { get; set; }


        /// <summary>Optional; the class name of the entity needed</summary>
        public string Entity_Type { get; set; }

        /// <summary>Optional; the id of the entity</summary>
        public string Entity_Id { get; set; }


        /// <summary>Optional; the message found in the exception thrown when running the action</summary>
        public string Exception { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
