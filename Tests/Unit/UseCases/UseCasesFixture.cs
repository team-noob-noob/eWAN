using eWAN.Application.Services;
using eWAN.Domains.Application;
using Moq;

namespace eWAN.Tests.Unit.UseCases
{
    public class UseCasesFixture
    {
        public IApplicationFactory applicationFactory;
        public Mock<IApplicationRepository> mockedApplicationRepository;
        public IMock<IUnitOfWork> mockedUnitOfWork;
    }
}
