namespace eWAN.Core.Infrastructure.Database.Repositories
{
    using System.Threading.Tasks;
    using Domains.Account;
    using Account = Entities.Account;

    public sealed class AccountRepository : IAccountRepository
    {
        private SchoolContext _context { get; }

        public AccountRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task AddAccount(IAccount account)
        {
            await _context.accounts.AddAsync(account as Account).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
