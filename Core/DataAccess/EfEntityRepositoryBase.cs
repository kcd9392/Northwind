using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess;

public class EfEntityRepositoryBase<T,TContext> :IEntityRepository<T> 
    where T:class,IEntity,new()
    where TContext:DbContext,new()
{
    public T Get(Expression<Func<T, bool>> filter)
    {
        using (var context = new TContext())
        {
            return context.Set<T>().SingleOrDefault(filter);
        }
    }

    public IList<T> GetList(Expression<Func<T, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter == null
                ? context.Set<T>().ToList()
                : context.Set<T>().Where(filter).ToList();
        }
    }

    public void Add(T entity)
    {
        using (var context = new TContext())
        {
            var addedEntity= context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(T entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(T entity)
    {
        using (var context=new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}