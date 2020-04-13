namespace eWAN.Core.Application.Boundaries
{
    public interface IOutputPortError
    {
        void WriteError(string message);
    }
}
