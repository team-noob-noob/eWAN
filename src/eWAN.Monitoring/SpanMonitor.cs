using System;
using Castle.DynamicProxy;

namespace eWAN.Monitoring
{
    public class SpanMonitoring : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var currentSpan = Elastic.Apm.Agent.Tracer.CurrentSpan;
            var childSpan = currentSpan.StartSpan(invocation.Method.Name, "");
            try
            {
                invocation.Proceed();
            }
            catch(Exception e)
            {
                childSpan.CaptureException(e);
                throw;
            }
            finally
            {
                childSpan.End();
            }
        }
    }
}