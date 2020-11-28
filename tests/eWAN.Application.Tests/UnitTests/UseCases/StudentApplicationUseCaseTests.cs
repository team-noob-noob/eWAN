using Xunit;
using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace eWAN.Tests.UnitTests.UseCases.StudentApplication
{
    using Fakes;
    using Application.UseCases;
    using Application.Boundaries.StudentApplication;

    public sealed class StudentApplicationUseCaseTests : IClassFixture<StandardFixture>, IDisposable
    {
        public StudentApplicationUseCaseTests(StandardFixture fixture)
        {
            Fixture = fixture;
        }

        private StandardFixture Fixture { get; } 

        [Theory]
        [ClassData(typeof(InvalidStudentApplication))]
        public async Task SendApplication_ExistingApplicationWIthin6Months_ShouldReturnError(StudentApplicationInput input)
        {
            // Arrange
            var studentApplicationPresenterFake = new StudentApplicationPresenterFake();
            Fixture.EwanContextFake.Applications.Add(EwanContextFake.TestApplication);
            var sut = new StudentApplicationUseCase(
                Fixture.EntityFactory,
                Fixture.ApplicationRepositoryFake,
                Fixture.UnitOfWorkFake,
                studentApplicationPresenterFake
            );
            

            // Act
            await sut.Handle(input);

            // Assert
            var actual = studentApplicationPresenterFake.ErrorOutput;
            var expected = "Applicant already applied within 6 months, please wait a while";
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(InvalidStudentApplication))]
        public async Task SendApplication_3ApplicationsSent_ShouldReturnError(StudentApplicationInput input)
        {
            // Arrange
            var studentApplicationPresenterFake = new StudentApplicationPresenterFake();
            Fixture.EwanContextFake.Applications.Add(EwanContextFake.TestApplication);
            Fixture.EwanContextFake.Applications.Add(EwanContextFake.TestApplication);
            Fixture.EwanContextFake.Applications.Add(EwanContextFake.TestApplication);
            var sut = new StudentApplicationUseCase(
                Fixture.EntityFactory,
                Fixture.ApplicationRepositoryFake,
                Fixture.UnitOfWorkFake,
                studentApplicationPresenterFake
            );
            
            // Act
            await sut.Handle(input);

            // Assert
            var actual = studentApplicationPresenterFake.ErrorOutput;
            var expected = "Applicant already surpassed the allowed limit of applications; Applicant is only allowed maximum of 3 applications";
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ValidStudentApplication))]
        public async Task SendApplication_ValidApplication_ShouldReturnStandard(StudentApplicationInput input)
        {
            // Arrange
            var studentApplicationPresenterFake = new StudentApplicationPresenterFake();
            var sut = new StudentApplicationUseCase(
                Fixture.EntityFactory,
                Fixture.ApplicationRepositoryFake,
                Fixture.UnitOfWorkFake,
                studentApplicationPresenterFake
            );

            // Act
            await sut.Handle(input);

            // Assert
            var actual = studentApplicationPresenterFake.StandardOutput;
            actual.Should().NotBe(null);
        }

        public void Dispose()
        {
            Fixture.Dispose();
        }
    }

    internal sealed class InvalidStudentApplication : TheoryData<StudentApplicationInput>
    {
        public InvalidStudentApplication() => this.Add(new StudentApplicationInput(EwanContextFake.TestUser));
    }

    internal sealed class ValidStudentApplication : TheoryData<StudentApplicationInput>
    {
        public ValidStudentApplication() => this.Add(new StudentApplicationInput(EwanContextFake.TestUser2));
    }
}
