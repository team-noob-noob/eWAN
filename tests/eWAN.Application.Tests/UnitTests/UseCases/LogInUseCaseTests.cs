using Xunit;
using System.Threading.Tasks;
using FluentAssertions;

namespace eWAN.Tests.UnitTests.UseCases.LogIn
{
    using Fakes;
    using Application.UseCases;
    using Application.Boundaries.LogIn;

    public sealed class LogInUseCaseTests : IClassFixture<StandardFixture>
    {
        private StandardFixture Fixture { get; }

        public LogInUseCaseTests(StandardFixture fixture) => Fixture = fixture;

        [Theory]
        [InlineData("testing", "testing")]
        public async Task LogIn_ValidCredential_ShouldReturnStandard(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                Fixture.UserRepositoryFake,
                Fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.StandardOutput.User.Username;
            actual.Should().Be(username);
        }

        [Theory]
        [InlineData("", "")]
        public async Task LogIn_EmptyCredentials_ShouldReturnError(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                Fixture.UserRepositoryFake,
                Fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.ErrorOutput;
            var expected = "Username or Password is empty";
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("testing123", "testing123")]
        public async Task LogIn_InvalidCredentials_ShouldReturnError(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                Fixture.UserRepositoryFake,
                Fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.ErrorOutput;
            var expected = "Incorrect Username or Password";
            actual.Should().Be(expected);
        }
    }
}
