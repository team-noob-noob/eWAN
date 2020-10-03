using Xunit;
using System.Threading.Tasks;
using eWAN.Application.UseCases;
using eWAN.Application.Boundaries.CreateProgram;
using eWAN.Tests.Fakes;
using FluentAssertions;
using System;

namespace eWAN.Tests.UnitTests.UseCases.CreateProgram
{
    public sealed class CreateProgramUseCaseTests : IClassFixture<StandardFixture>, IDisposable
    {
        public CreateProgramUseCaseTests(StandardFixture fixture) => _fixtures = fixture;
        private readonly StandardFixture _fixtures;
        public void Dispose() => _fixtures.Dispose();

        [Fact]
        public async Task CreateProgram_DuplicateCode_ShouldReturnError()
        {
            var presenter = new CreateProgramPresenterFake();
            var sut = new CreateProgramUseCase(
                presenter,
                _fixtures.ProgramRepositoryFake,
                _fixtures.EntityFactory,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateProgramInput(
                "Testing Program",
                EwanContextFake.TestProgram.Code,
                "Testing Program"
            );

            await sut.Handle(input);

            presenter.ErrorOutput.Should().NotBe(null);
            presenter.ErrorOutput.Should().Be("Code already taken");
        }

        [Fact]
        public async Task CreateProgram_DuplicateTitle_ShouldReturnError()
        {
            var presenter = new CreateProgramPresenterFake();
            var sut = new CreateProgramUseCase(
                presenter,
                _fixtures.ProgramRepositoryFake,
                _fixtures.EntityFactory,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateProgramInput(
                EwanContextFake.TestProgram.Title,
                "TEST",
                "Testing Program"
            );

            await sut.Handle(input);

            presenter.ErrorOutput.Should().NotBe(null);
            presenter.ErrorOutput.Should().Be("Title already taken");
        }

        [Fact]
        public async Task CreateProgram_ValidDetails_ShouldReturnStandard()
        {
            var presenter = new CreateProgramPresenterFake();
            var sut = new CreateProgramUseCase(
                presenter,
                _fixtures.ProgramRepositoryFake,
                _fixtures.EntityFactory,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateProgramInput(
                "Testing Program",
                "TEST",
                "Testing Program"
            );

            await sut.Handle(input);

            presenter.StandardOutput.Should().NotBe(null);
            presenter.StandardOutput.Program.Code.Should().Be("TEST");
        }

        
    }
}