using Microsoft.EntityFrameworkCore;
using ParkCinema.DataAccess.Contexts;
using ParkCinema.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace ParkCinema.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{


    private readonly AppDbContext _context;
    private DbSet<T> _table;

    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }



    public IQueryable<T> FindAll()
    {
        return _table.AsQueryable();
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
       return _table.Where(expression).AsNoTracking();
    }

    public async Task CreateAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }

    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
