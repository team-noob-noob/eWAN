namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.CreateProgram;
    using Domains.Program;
    using eWAN.Application.Services;

    public class CreateProgramUseCase : ICreateProgramUseCase
    {
        public CreateProgramUseCase(
            ICreateProgramOutputPort outputPort,
            IProgramRepository programRepository,
            IProgramFactory factory,
            IUnitOfWork unitOfWork
        )
        {
            this._outputPort = outputPort;
            this._programRepository = programRepository;
            this._programFactory = factory;
            this._unitOfWork = unitOfWork;
        }

        private ICreateProgramOutputPort _outputPort { get; }
        private IProgramRepository _programRepository { get; }
        private IProgramFactory _programFactory { get; }
        private IUnitOfWork _unitOfWork;

        public async Task Handle(CreateProgramInput input)
        {
            if(!(await this._programRepository.GetProgramByTitle(input.Title) is null))
            {
                this._outputPort.WriteError("Title already taken");
                return;
            }

            if(!(await this._programRepository.GetProgramByCode(input.Code) is null))
            {
                this._outputPort.WriteError("Code already taken");
                return;
            }

            IProgram newProgram = this._programFactory.NewProgram(input.Title, input.Code, input.Description, null);

            await this._programRepository.Add(newProgram);

            this._outputPort.Standard(new CreateProgramOutput(newProgram));

            await this._unitOfWork.Save();
        }
    }
}
