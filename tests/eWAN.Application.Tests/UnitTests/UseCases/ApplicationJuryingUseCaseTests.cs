using System.Threading.Tasks;
using Xunit;

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
            var expected = "Invalid Application Id";

            // Act
            await sut.Handle(input);

            // Assert
            var actual = applicationJuryingPresenterFake.ErrorOutput;
            Assert.StrictEqual<string>(expected, actual);
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
            var expected = input.ApplicationId;

            // Act
            await sut.Handle(input);

            // Assert
            var actual = applicationJuryingPresenterFake.StandardOutput.StudentApplicationResult.Id;
            Assert.StrictEqual<string>(expected, actual);
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
