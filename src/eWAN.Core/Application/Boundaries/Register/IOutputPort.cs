namespace eWAN.Core.Application.Boundaries.Register
{
    public interface IOutputPort
        : IOutputPortError, IOutputPortStandard<RegisterOutput>
    {
        void UserAlreadyRegistered(RegisterOutput output);
    }
}
