using eWAN.Application.Boundaries.CreateRoom;

namespace eWAN.Tests.Fakes
{
    public sealed class CreateRoomPresenterFake : ICreateRoomOutputPort
    {
        public CreateRoomOutput StandardOutput;
        public string ErrorOutput;

        public void Standard(CreateRoomOutput output) => this.StandardOutput = output;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
