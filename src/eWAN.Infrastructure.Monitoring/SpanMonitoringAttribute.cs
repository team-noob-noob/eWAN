using System.Threading.Tasks;
using AspectCore.DynamicProxy;

namespace eWAN.Infrastructure.Monitoring
{
    public class SpanMonitoringAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
            if(transaction != null)
                // TODO: Add Proper values/data in type param
                await transaction.CaptureSpan(context.ServiceMethod.Name, "", async () => {
                    await next(context);
                });
        }
    }
}
