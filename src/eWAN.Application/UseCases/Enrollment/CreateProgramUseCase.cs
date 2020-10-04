namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.CreateProgram;
    using Domains.Program;
    using Services;

    public class CreateProgramUseCase : ICreateProgramUseCase
    {
        public CreateProgramUseCase(
            ICreateProgramOutputPort outputPort,
            IProgramRepository programRepository,
            IProgramFactory factory,
            IUnitOfWork unitOfWork
        )
        {
            OutputPort = outputPort;
            ProgramRepository = programRepository;
            ProgramFactory = factory;
            _unitOfWork = unitOfWork;
        }

        private ICreateProgramOutputPort OutputPort { get; }
        private IProgramRepository ProgramRepository { get; }
        private IProgramFactory ProgramFactory { get; }
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(CreateProgramInput input)
        {
            if(!(await ProgramRepository.GetProgramByTitle(input.Title) is null))
            {
                OutputPort.WriteError("Title already taken");
                return;
            }

            if(!(await ProgramRepository.GetProgramByCode(input.Code) is null))
            {
                OutputPort.WriteError("Code already taken");
                return;
            }

            IProgram newProgram = ProgramFactory.NewProgram(input.Title, input.Code, input.Description, null);

            await ProgramRepository.Add(newProgram);

            OutputPort.Standard(new CreateProgramOutput(newProgram));

            await _unitOfWork.Save();
        }
    }
}
