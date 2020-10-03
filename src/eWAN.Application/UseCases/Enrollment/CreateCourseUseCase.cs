namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.CreateCourse;
    using Domains.Course;
    using Services;

    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        public CreateCourseUseCase(
            ICreateCourseOutputPort outputPort,
            ICourseFactory courseFactory,
            ICourseRepository repository,
            IUnitOfWork unitOfWork
        )
        {
            _outputPort = outputPort;
            _repo = repository;
            _factory = courseFactory;
            _unitOfWork = unitOfWork;
        }

        private readonly ICreateCourseOutputPort _outputPort;
        private readonly ICourseRepository _repo;
        private readonly ICourseFactory _factory;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(CreateCourseInput input)
        {
            if(await _repo.GetCourseById(input.Id) != null)
            {
                _outputPort.WriteError("Id already taken");
                return;
            }

            if(await _repo.GetCourseByTitle(input.Title) != null)
            {
                _outputPort.WriteError("Title already taken");
                return;
            }

            var course = _factory.NewCourse(input.Id, input.Title, input.Description, input.Prerequisites, input.Program);

            await _repo.Add(course);

            _outputPort.Standard(new CreateCourseOutput(course));

            await _unitOfWork.Save();
        }
    }
}
