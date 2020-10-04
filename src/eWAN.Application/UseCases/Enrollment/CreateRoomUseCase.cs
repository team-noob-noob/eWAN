namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.CreateRoom;
    using Domains.Room;
    using Services;

    public class CreateRoomUseCase : ICreateRoomUseCase
    {
        public CreateRoomUseCase(
            IRoomRepository roomRepository,
            IRoomFactory roomFactory,
            ICreateRoomOutputPort outputPort,
            IUnitOfWork unitOfWork
        )
        {
            _roomRepo = roomRepository;
            _roomFactory = roomFactory;
            _output = outputPort;
            _unitOfWork = unitOfWork;
        }

        private readonly IRoomRepository _roomRepo;
        private readonly IRoomFactory _roomFactory;
        private readonly ICreateRoomOutputPort _output;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(CreateRoomInput input)
        {
            if(await _roomRepo.GetRoomById(input.Id) != null)
            {
                _output.WriteError("Id already taken");
                return;
            }


            var room = _roomFactory.NewRoom(input.Id, input.Name, input.Address);
            await _roomRepo.Add(room);

            _output.Standard(new CreateRoomOutput(room));

            await _unitOfWork.Save();
        }
    }
}
