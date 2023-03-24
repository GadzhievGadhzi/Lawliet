namespace Lawliet.Interfaces {
    public interface IGenericRepository<TEntity> where TEntity : class {
        public Task CreateAsync(TEntity item);
        public Task<TEntity> FindById<TArg>(TArg id);
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        public void Remove(TEntity item);
        public void Update(TEntity item);
    }
}