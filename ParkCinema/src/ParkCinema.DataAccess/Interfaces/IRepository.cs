using ParkCinema.Core.Interfaces;
using System.Linq.Expressions;

namespace ParkCinema.DataAccess.Interfaces;

public interface IRepository<T> where T : class, IEntity, new()
{
    IQueryable<T> FindAll();
    Task<T?> FindByIdAsync(int id);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
