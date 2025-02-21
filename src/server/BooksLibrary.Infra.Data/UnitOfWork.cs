using BooksLibrary.Domain.Interfaces.SeedWork;
using BooksLibrary.Infra.Data.Context;

namespace BooksLibrary.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appContext;

        public UnitOfWork(AppDbContext appContext)
        {
            this._appContext = appContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this._appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
