using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace eWAN.Monitoring
{
    // https://github.com/JSkimming/Castle.Core.AsyncInterceptor
    public class SpanMonitor : IAsyncInterceptor
    {
        public void InterceptSynchronous(IInvocation invocation)
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

        public void InterceptAsynchronous(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsynchronous(invocation);
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            invocation.ReturnValue = InternalInterceptAsynchronousWithResult<TResult>(invocation);
        }

        private async Task<TResult> InternalInterceptAsynchronousWithResult<TResult>(IInvocation invocation)
        {
            var currentTransaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
            var childSpan = currentTransaction.StartSpan(invocation.Method.ReflectedType.Namespace + " " + invocation.Method.ToString(), "");
            TResult result;
            try
            {
                invocation.Proceed();
                var task = (Task<TResult>)invocation.ReturnValue;
                result = await task;
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

            return result;
        }

        private async Task InternalInterceptAsynchronous(IInvocation invocation)
        {
            var currentTransaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
            var childSpan = currentTransaction.StartSpan(invocation.Method.ReflectedType.Namespace + " " + invocation.Method.ToString(), "");
            try
            {
                invocation.Proceed();
                var task = (Task)invocation.ReturnValue;
                await task;
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