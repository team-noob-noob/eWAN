using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System;
using eWAN.Tests.Fakes;
using eWAN.Application.UseCases;
using eWAN.Application.Boundaries.CreateRoom;

namespace eWAN.Tests.UnitTests.UseCases.CreateRoom
{
    public sealed class CreateRoomUseCaseTests : IClassFixture<StandardFixture>, IDisposable
    {
        public CreateRoomUseCaseTests(StandardFixture fixture) => _fixtures = fixture;
        private readonly StandardFixture _fixtures;
        public void Dispose() => _fixtures.Dispose();

        [Fact]
        public async Task CreateRoom_DuplicateId_ShouldReturnError()
        {
            var presenter = new CreateRoomPresenterFake();
            var sut = new CreateRoomUseCase(
                _fixtures.RoomRepositoryFake,
                _fixtures.EntityFactory,
                presenter,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateRoomInput(
                EwanContextFake.TestRoom.Code,
                "Testing Room",
                "Testing Room building"
            );

            await sut.Handle(input);

            presenter.ErrorOutput.Should().NotBe(null);
            presenter.ErrorOutput.Should().Contain("Id already taken");
        }

        [Fact]
        public async Task CreateRoom_ValidDetails_ShouldReturnStandard()
        {
            var presenter = new CreateRoomPresenterFake();
            var sut = new CreateRoomUseCase(
                _fixtures.RoomRepositoryFake,
                _fixtures.EntityFactory,
                presenter,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateRoomInput(
                "Testing Room",
                "Testing Room",
                "Testing Room building"
            );

            await sut.Handle(input);

            presenter.StandardOutput.Should().NotBe(null);
            presenter.StandardOutput.NewRoom.Code.Should().Be("Testing Room");
        }
    }
}
