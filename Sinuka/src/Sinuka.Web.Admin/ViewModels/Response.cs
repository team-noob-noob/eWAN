using System;

namespace Sinuka.Web.Admin.ViewModels
{
    public class Response<T>
    {
        public Response(T value)
        {
            this.Value = value;
        }

        public DateTime time { get; set; } = DateTime.UtcNow;
        public T Value { get; set; }
    }
}
