namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.CreateCourse;
    using Domains.Course;
    using eWAN.Application.Services;

    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        public CreateCourseUseCase(
            ICreateCourseOutputPort outputPort,
            ICourseFactory courseFactory,
            ICourseRepository repository,
            IUnitOfWork unitOfWork
        )
        {
            this._outputPort = outputPort;
            this._repo = repository;
            this._factory = courseFactory;
            this._unitOfWork = unitOfWork;
        }

        private readonly ICreateCourseOutputPort _outputPort;
        private readonly ICourseRepository _repo;
        private readonly ICourseFactory _factory;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(CreateCourseInput input)
        {
            if(await this._repo.GetCourseById(input.Id) != null)
            {
                this._outputPort.WriteError("Id already taken");
                return;
            }

            if(await this._repo.GetCourseByTitle(input.Title) != null)
            {
                this._outputPort.WriteError("Title already taken");
                return;
            }

            var course = this._factory.NewCourse(input.Id, input.Title, input.Description, input.Prerequisites, input.Program);

            await this._repo.Add(course);

            this._outputPort.Standard(new CreateCourseOutput(course));

            await this._unitOfWork.Save();
        }
    }
}
