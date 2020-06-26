using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace eWAN.Tests.Unit.UseCases.Application
{
    using eWAN.Application.UseCases;
    using eWAN.Application.Boundaries.ApplicationJurying;
    using Domains.Application;
    using Domains.User;
    using eWAN.Application.Services;

    public class ApplicationJuryingUseCaseTests : UseCasesFixture
    {
        [SetUp]
        public void Setup()
        {
            this.mockedApplicationRepository = new Mock<IApplicationRepository>();
            this.mockedOutputPort = new Mock<IApplicationJuryingOutputPort>();
            this.mockedUnitOfWork = new Mock<IUnitOfWork>();
            this.sut = new ApplicationJuryingUseCase(
                this.mockedApplicationRepository.Object,
                this.mockedOutputPort.Object,
                this.mockedUnitOfWork.Object
            );
            this.mockedJury = new Mock<IUser>();
        }

        private ApplicationJuryingUseCase sut;
        private Mock<IApplicationJuryingOutputPort> mockedOutputPort;
        private Mock<IUser> mockedJury;

        [Test]
        public async Task Jurying_ApplicationIsRejected_ShouldCallStandard()
        {
            // Arrange
            var applicationId = It.IsAny<string>();
            var rejectedApplication = false;
            var reason = It.IsAny<string>();
            var input = new ApplicationJuryingInput(
                applicationId,
                this.mockedJury.Object,
                rejectedApplication,
                reason
            );
            var mockedApplication = new Mock<IApplication>();
            this.mockedApplicationRepository.Setup(x => x.GetApplicationById(It.IsAny<string>())).Returns(mockedApplication.Object);

            // Act
            await this.sut.Handle(input);

            // Assert
            this.mockedOutputPort.Verify(x => x.Standard(It.IsAny<ApplicationJuryingOutput>()), Times.Once);
        }

        [Test]
        public async Task Jurying_ApplicatoionIsAccepted_ShouldCallStandard()
        {
            // Arrange
            var applicationId = It.IsAny<string>();
            var acceptedApplication = false;
            var reason = It.IsAny<string>();
            var input = new ApplicationJuryingInput(
                applicationId,
                this.mockedJury.Object,
                acceptedApplication,
                reason
            );
            var mockedApplication = new Mock<IApplication>();
            this.mockedApplicationRepository.Setup(x => x.GetApplicationById(It.IsAny<string>())).Returns(mockedApplication.Object);

            // Act
            await this.sut.Handle(input);

            // Assert
            this.mockedOutputPort.Verify(x => x.Standard(It.IsAny<ApplicationJuryingOutput>()), Times.Once);
        }

        [Test]
        public async Task Jurying_InvalidApplicationId_ShouldCallWriteError()
        {
            // Arrange
            string invalidApplicationId = "";
            var acceptedApplication = false;
            var reason = It.IsAny<string>();
            var input = new ApplicationJuryingInput(
                invalidApplicationId,
                this.mockedJury.Object,
                acceptedApplication,
                reason
            );
            this.mockedApplicationRepository.Setup(x => x.GetApplicationById(It.IsAny<string>()));

            // Act
            await this.sut.Handle(input);

            // Assert
            this.mockedOutputPort.Verify(x => x.WriteError(It.IsAny<string>()), Times.Once);
        }
    }
}
