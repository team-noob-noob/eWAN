using System.Linq;
using System.Collections.Generic;

namespace Sinuka.Web.Admin.Extensions 
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> list, int pageNumber = 1, int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
