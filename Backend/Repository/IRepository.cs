namespace Backend.Repository;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> Get();
    Task<TEntity> GetById(int id);
    Task Add(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    Task Save();
    IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
}
