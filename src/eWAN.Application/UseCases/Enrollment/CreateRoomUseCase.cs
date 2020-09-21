namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.CreateRoom;
    using Domains.Room;
    using eWAN.Application.Services;

    public class CreateRoomUseCase : ICreateRoomUseCase
    {
        public CreateRoomUseCase(
            IRoomRepository roomRepository,
            IRoomFactory roomFactory,
            ICreateRoomOutputPort outputPort,
            IUnitOfWork unitOfWork
        )
        {
            this._roomRepo = roomRepository;
            this._roomFactory = roomFactory;
            this._output = outputPort;
            this._unitOfWork = unitOfWork;
        }

        private readonly IRoomRepository _roomRepo;
        private readonly IRoomFactory _roomFactory;
        private readonly ICreateRoomOutputPort _output;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(CreateRoomInput input)
        {
            if(await this._roomRepo.GetRoomById(input.Id) != null)
            {
                this._output.WriteError("Id already taken");
                return;
            }


            var room = this._roomFactory.NewRoom(input.Id, input.Name, input.Address);
            await this._roomRepo.Add(room);

            this._output.Standard(new CreateRoomOutput(room));

            await this._unitOfWork.Save();
        }
    }
}
