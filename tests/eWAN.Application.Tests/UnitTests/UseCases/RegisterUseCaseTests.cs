using System.Threading.Tasks;
using Xunit;
using System;
using FluentAssertions;

namespace eWAN.Tests.UnitTests.UseCases.Reguster
{
    using Fakes;
    using Application.UseCases;
    using Application.Boundaries.Register;
    using User = Infrastructure.Database.Entities.User;

    public sealed class RegisterUseCaseTests : IClassFixture<StandardFixture>, IDisposable
    {
        public RegisterUseCaseTests(StandardFixture fixture) => this._fixture = fixture;
        private StandardFixture _fixture { get; }

        [Theory]
        [ClassData(typeof(DuplicateUsername))]
        public async Task Register_DuplicateUsername_ShouldReturnError(RegisterInput input)
        {
            // Arrange
            var registerPresenterFake = new RegisterPresenterFake();
            var sut = new RegisterUseCase(
                registerPresenterFake,
                this._fixture.UserRepositoryFake,
                this._fixture.RoleRepositoryFake,
                this._fixture.EntityFactory,
                this._fixture.EntityFactory,
                this._fixture.UnitOfWorkFake,
                this._fixture.BcryptHashing
            );
            
            // Act
            await sut.Handle(input);

            // Assert
            var actual = registerPresenterFake.ErrorOutput;
            var expected = "Username already taken";
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(DuplicateEmail))]
        public async Task Register_DuplicateEmail_ShouldReturnError(RegisterInput input)
        {
            // Arrange
            var registerPresenterFake = new RegisterPresenterFake();
            this._fixture.EwanContextFake.Users.Add((User) this._fixture.EntityFactory.NewUser(
                "testing123341132123",      // Username
                "testing",                  // Password

                "testing@testing.testing123123",  // Email
                "0900000000",               // Phone Number

                "Testing",                  // FirstName
                "Testing",                  // MiddleName
                "Testing",                  // LastName

                "Testing"                   // Address
            ));
            var sut = new RegisterUseCase(
                registerPresenterFake,
                this._fixture.UserRepositoryFake,
                this._fixture.RoleRepositoryFake,
                this._fixture.EntityFactory,
                this._fixture.EntityFactory,
                this._fixture.UnitOfWorkFake,
                this._fixture.BcryptHashing
            );

            // Act
            await sut.Handle(input);

            // Assert
            var actual = registerPresenterFake.ErrorOutput;
            var expected = "Email already taken";
            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(ValidData))]
        public async Task Register_ValidData_ShouldReturnStandard(RegisterInput input)
        {
            // Arrange
            var registerPresenterFake = new RegisterPresenterFake();
            var sut = new RegisterUseCase(
                registerPresenterFake,
                this._fixture.UserRepositoryFake,
                this._fixture.RoleRepositoryFake,
                this._fixture.EntityFactory,
                this._fixture.EntityFactory,
                this._fixture.UnitOfWorkFake,
                this._fixture.BcryptHashing
            );

            // Act
            await sut.Handle(input);

            // Assert
            var actual = registerPresenterFake.StandardOutput.newUser.Username;
            var expected = "testing321312312123";
            actual.Should().Be(expected);
        }

        public void Dispose()
        {
            this._fixture.Dispose();
        }
    }

    internal class DuplicateUsername : TheoryData<RegisterInput>
    {
        public DuplicateUsername() => this.Add(new RegisterInput(
            "testing",              // Username
            "testing",              // Password

            "testing@email.emaei",  // Email
            "0900000000",           // Phone Number

            "Testing",              // FirstName
            "Testing",              // MiddleName
            "Testing",              // LastName

            "Testing"               // Address
        ));
    }

    internal class DuplicateEmail : TheoryData<RegisterInput>
    {
        public DuplicateEmail() => this.Add(new RegisterInput(
            "testing123333",            // Username
            "testing",                  // Password

            "testing@testing.testing",  // Email
            "0900000000",               // Phone Number

            "Testing",                  // FirstName
            "Testing",                  // MiddleName
            "Testing",                  // LastName

            "Testing"                   // Address
        ));
    }

    internal class ValidData : TheoryData<RegisterInput>
    {
        public ValidData() => this.Add(new RegisterInput(
            "testing321312312123",          // Username
            "testing",                      // Password

            "test123123123123@test.test",   // Email
            "0900 0000 000",                // Phone Number

            "test",                         // FirstName
            "test",                         // MiddleName
            "tes",                          // LastName

            "test"                          // Address
        ));
    }
}
