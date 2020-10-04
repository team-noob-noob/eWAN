using Xunit;
using System.Threading.Tasks;
using eWAN.Tests.Fakes;
using eWAN.Application.UseCases;
using eWAN.Application.Boundaries.CreateCourse;
using FluentAssertions;
using System;

namespace eWAN.Tests.UnitTests.UseCases.CreateCourse
{
    public sealed class CreateCourseUseCaseTests : IClassFixture<StandardFixture>, IDisposable
    {
        public CreateCourseUseCaseTests(StandardFixture fixture) => _fixtures = fixture;
        private readonly StandardFixture _fixtures;

        [Fact]
        public async Task CreateCourse_DuplicateId_ShouldReturnError()
        {
            var presenter = new CreateCoursePresenterFake();
            var sut = new CreateCourseUseCase(
                presenter,
                _fixtures.EntityFactory,
                _fixtures.CourseRepositoryFake,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateCourseInput(
                EwanContextFake.TestCourse.Id,
                "Testing Course",
                "Testing Course",
                null,
                EwanContextFake.TestProgram
            );

            await sut.Handle(input);

            presenter.ErrorOutput.Should().NotBe(null);
            presenter.ErrorOutput.Should().Be("Id already taken");
        }

        [Fact]
        public async Task CreateCourse_DuplicateTitle_ShouldReturnError()
        {
            var presenter = new CreateCoursePresenterFake();
            var sut = new CreateCourseUseCase(
                presenter,
                _fixtures.EntityFactory,
                _fixtures.CourseRepositoryFake,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateCourseInput(
                "Testing Course",
                EwanContextFake.TestCourse.Title,
                "Testing Course",
                null,
                EwanContextFake.TestProgram
            );

            await sut.Handle(input);

            presenter.ErrorOutput.Should().NotBe(null);
            presenter.ErrorOutput.Should().Be("Title already taken");
        }

        [Fact]
        public async Task CreateCourse_ValidDetails_ShouldReturnStandard()
        {
            var presenter = new CreateCoursePresenterFake();
            var sut = new CreateCourseUseCase(
                presenter,
                _fixtures.EntityFactory,
                _fixtures.CourseRepositoryFake,
                _fixtures.UnitOfWorkFake
            );
            var input = new CreateCourseInput(
                "Testing Course",
                "Testing Course",
                "Testing Course",
                null,
                EwanContextFake.TestProgram
            );

            await sut.Handle(input);

            presenter.StandardOutput.Should().NotBe(null);
            presenter.StandardOutput.Course.Id.Should().Be("Testing Course");
        }

        public void Dispose() => _fixtures.Dispose();
    }
}