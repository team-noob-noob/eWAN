namespace eWAN.Application.Boundaries
{
    public interface IOutputPort<TUseCaseOutput>
    {
        void WriteError(string message);
        void Standard(TUseCaseOutput output);
    }
}
