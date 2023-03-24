using Lawliet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lawliet.Data {
    public class DataRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public DataRepository(DbContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> FindById<TArg>(TArg id) {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task CreateAsync(TEntity item) {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity item) {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity item) {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}