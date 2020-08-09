using System.Threading.Tasks;

namespace eWAN.Tests.Fakes
{
    using Application.Services;

    public sealed class UnitOfWorkFake : IUnitOfWork
    {
        public async Task<int> Save() => await Task.FromResult(0).ConfigureAwait(false);
    }
}
