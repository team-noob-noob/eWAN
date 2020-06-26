using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace eWAN.Tests.Unit.UseCases.Application
{
    using eWAN.Application.UseCases;
    using eWAN.Application.Services;
    using eWAN.Application.Boundaries.StudentApplication;
    using Domains.Application;
    using Domains.User;
    using Mocks;

    public class StudentApplicationUseCaseTests
    {
        private IApplicationFactory applicationFactory;
        private Mock<IApplicationRepository> mockedApplicationRepository;
        private Mock<IUnitOfWork> mockedUnitOfWork;
        private Mock<IStudentApplicationOutputPort> mockedOutputPort;
        private Mock<IUser> mockedApplicant;
        private StudentApplicationUseCase sut;

        [SetUp]
        public void Setup()
        {
            this.applicationFactory = new Infrastructure.Database.EntityFactory();

            this.mockedApplicationRepository = new Mock<IApplicationRepository>();

            this.mockedUnitOfWork = new Mock<IUnitOfWork>();

            this.mockedOutputPort = new Mock<IStudentApplicationOutputPort>();

            this.mockedApplicant = new Mock<IUser>();
        }

        [Test]
        public async Task PassingApplication_ApplicantHaveAppliedWithinSixMonthsFromToday_ShouldCallErrorOutput()
        {
            // Arrange
            var mockedApplicationQueryResult = new Mock<List<IApplication>>().Object;
            mockedApplicationQueryResult.Add(new MockedApplicationEntity(DateTime.Now.AddMonths(-1)));
            var input = new StudentApplicationInput(this.mockedApplicant.Object);
            this.mockedApplicationRepository.Setup(x => x.GetApplicationsByApplicantId(It.IsAny<string>())).Returns(mockedApplicationQueryResult);
            this.sut = new StudentApplicationUseCase(
                this.applicationFactory, 
                this.mockedApplicationRepository.Object,
                this.mockedUnitOfWork.Object,
                this.mockedOutputPort.Object);

            // Act
            await this.sut.Handle(input).ConfigureAwait(false);

            // Assert
            this.mockedOutputPort.Verify(x => x.WriteError(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task PassingApplication_ApplicantHaveAppliedThreeTimes_ShouldCallErrorOutput()
        {
            // Arrange
            var mockedApplicationQueryResult = new Mock<List<IApplication>>().Object;
            mockedApplicationQueryResult.Add(new MockedApplicationEntity());
            mockedApplicationQueryResult.Add(new MockedApplicationEntity());
            mockedApplicationQueryResult.Add(new MockedApplicationEntity());
            this.mockedApplicationRepository.Setup(x => x.GetApplicationsByApplicantId(It.IsAny<string>())).Returns(mockedApplicationQueryResult);
            var input = new StudentApplicationInput(this.mockedApplicant.Object);
            this.sut = new StudentApplicationUseCase(
                this.applicationFactory,
                this.mockedApplicationRepository.Object,
                this.mockedUnitOfWork.Object,
                this.mockedOutputPort.Object
            );

            // Act
            await this.sut.Handle(input).ConfigureAwait(false);

            // Assert
            this.mockedOutputPort.Verify(x => x.WriteError(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task PassingApplication_WaitedForSixMonths_ShouldCallStandardOutput()
        {
            // Arrange
            var mockedApplicationQueryResult = new Mock<List<IApplication>>().Object;
            mockedApplicationQueryResult.Add(new MockedApplicationEntity(DateTime.Now.AddMonths(-6)));
            this.mockedApplicationRepository.Setup(x => x.GetApplicationsByApplicantId(It.IsAny<string>())).Returns(mockedApplicationQueryResult);
            var input = new StudentApplicationInput(this.mockedApplicant.Object);
            this.sut = new StudentApplicationUseCase(
                this.applicationFactory,
                this.mockedApplicationRepository.Object,
                this.mockedUnitOfWork.Object,
                this.mockedOutputPort.Object
            );

            // Act
            await this.sut.Handle(input).ConfigureAwait(false);

            // Assert
            this.mockedOutputPort.Verify(x => x.Standard(It.IsAny<StudentApplicationOutput>()), Times.Once);
        }
    }
}
