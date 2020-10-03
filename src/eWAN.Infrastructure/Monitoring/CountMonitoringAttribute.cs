using System.Threading.Tasks;
using AspectCore.DynamicProxy;

namespace eWAN.Infrastructure.Monitoring
{
    public class CountMonitoringAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}
