using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Interfaces.Repository;
using BooksLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Infra.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context { get; }
        

        protected Repository(AppDbContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        private DbSet<T> _dbSet => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
