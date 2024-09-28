
using DEPI9APITask.DAL.Contexts;

namespace DEPI9APITask.DAL;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DEPI9APITaskContext _appContext;
    public GenericRepository(DEPI9APITaskContext appContext)
    {
        _appContext = appContext;
    }

    public List<TEntity> GetAll()
    {
        return _appContext.Set<TEntity>().ToList();
    }

    public TEntity? GetById(int id)
    {
        return _appContext.Set<TEntity>().Find(id);
    }
    public void Add(TEntity entity)
    {
        _appContext.Set<TEntity>().Add(entity);
    }
    public void Update(TEntity entity)
    {
        //_appContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _appContext.Set<TEntity>().Remove(entity);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if(entity is not null)
            _appContext.Set<TEntity>().Remove(entity);
    }
   
    public void SaveChanges()
    {
        _appContext.SaveChanges();
    }
}
