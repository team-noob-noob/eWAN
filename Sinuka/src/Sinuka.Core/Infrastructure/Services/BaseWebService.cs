using Refit;

namespace Sinuka.Core.Infrastructure.Services
{
    public class BaseWebService<T>
    {
        protected T WebService;

        public BaseWebService(string baseUrl)
        {
            WebService = RestService.For<T>(baseUrl);
        }
    }
}
