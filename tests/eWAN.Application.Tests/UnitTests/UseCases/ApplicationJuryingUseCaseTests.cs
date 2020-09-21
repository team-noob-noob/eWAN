using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace eWAN.Tests.UnitTests.UseCases.ApplicationJurying
{
    using Application.Boundaries.ApplicationJurying;
    using Application.UseCases;
    using Fakes;

    public sealed class ApplicationJuryingUseCaseTests : IClassFixture<StandardFixture>
    {
        public ApplicationJuryingUseCaseTests(StandardFixture fixture) => this._fixture = fixture;
        private StandardFixture _fixture { get; }

        [Theory]
        [ClassData(typeof(InvalidApplicationId))]
        public async Task Judging_InvalidApplicationId_ShouldReturnError(ApplicationJuryingInput input)
        {
            // Arrange
            var applicationJuryingPresenterFake = new ApplicationJuryingPresenterFake();
            var sut = new ApplicationJuryingUseCase(
                this._fixture.ApplicationRepositoryFake,
                applicationJuryingPresenterFake,
                this._fixture.RoleRepositoryFake,
                this._fixture.UnitOfWorkFake
            );

            // Act
            await sut.Handle(input);

            // Assert
            var actual = applicationJuryingPresenterFake.ErrorOutput;
            var expected = "Invalid Application Id";
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ValidApplicationId))]
        public async Task Judging_ValidApplicationId_ShouldReturnStandard(ApplicationJuryingInput input)
        {
            // Arrange
            var applicationJuryingPresenterFake = new ApplicationJuryingPresenterFake();
            var sut = new ApplicationJuryingUseCase(
                this._fixture.ApplicationRepositoryFake,
                applicationJuryingPresenterFake,
                this._fixture.RoleRepositoryFake,
                this._fixture.UnitOfWorkFake
            );

            // Act
            await sut.Handle(input);

            // Assert
            var actual = applicationJuryingPresenterFake.StandardOutput.StudentApplicationResult.Id;
            var expected = input.ApplicationId;
            actual.Should().Be(expected);
        }
    }

    internal sealed class InvalidApplicationId : TheoryData<ApplicationJuryingInput>
    {
        public InvalidApplicationId() => this.Add(new ApplicationJuryingInput(string.Empty, EwanContextFake.TestUser, false, string.Empty));
    }

    internal sealed class ValidApplicationId : TheoryData<ApplicationJuryingInput>
    {
        public ValidApplicationId() => this.Add(new ApplicationJuryingInput(EwanContextFake.TestApplication.Id, EwanContextFake.TestUser, false, string.Empty));
    }
}
