using Xunit;
using System.Threading.Tasks;

namespace eWAN.Tests.UnitTests.UseCases.LogIn
{
    using Fakes;
    using Application.UseCases;
    using Application.Boundaries.LogIn;

    public sealed class LogInUseCaseTests : IClassFixture<StandardFixture>
    {
        private StandardFixture _fixture { get; }

        public LogInUseCaseTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidCredentials))]
        public async Task LogIn_ValidCredential(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                this._fixture.UserRepositoryFake,
                this._fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.StandardOutput.user.Username;
            Assert.StrictEqual<string>(username, actual);
        }

        [Theory]
        [ClassData(typeof(EmptyCredentials))]
        public async Task LogIn_EmptyCredentials(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                this._fixture.UserRepositoryFake,
                this._fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);
            var expected = "Username or Password is empty";

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.ErrorOutput;
            Assert.StrictEqual<string>(expected, actual);
        }

        [Theory]
        [ClassData(typeof(InvalidCredentials))]
        public async Task LogIn_InvalidCredentials(
            string username,
            string password
        )
        {
            // Arrange
            var logInPresenter = new LogInPresenterFake();
            var sut = new LogInUseCase(
                logInPresenter,
                this._fixture.UserRepositoryFake,
                this._fixture.BcryptHashing
            );
            var input = new LogInInput(username, password);
            var expected = "Incorrect Username or Password";

            // Act
            await sut.Handle(input);

            // Assert
            var actual = logInPresenter.ErrorOutput;
            Assert.StrictEqual<string>(expected, actual);
        }
    }

    internal sealed class ValidCredentials : TheoryData<string, string>
    {
        public ValidCredentials() => this.Add("testing", "testing");
    }

    internal sealed class InvalidCredentials : TheoryData<string, string>
    {
        public InvalidCredentials() => this.Add("testing123", "testing123");
    }

    internal sealed class EmptyCredentials : TheoryData<string, string>
    {
        public EmptyCredentials() => this.Add(string.Empty, string.Empty);
    }
}
