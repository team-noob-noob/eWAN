namespace eWAN.Application.Boundaries
{
    public interface IOutputPort<in TUseCaseOutput>
    {
        void WriteError(string message);
        void Standard(TUseCaseOutput output);
    }
}
