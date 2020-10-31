using System;
using Castle.DynamicProxy;

namespace eWAN.Monitoring
{
    public class SpanMonitor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var currentTransaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
            var childSpan = currentTransaction.StartSpan(invocation.Method.ReflectedType.Namespace + " " + invocation.Method.ToString(), "");
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