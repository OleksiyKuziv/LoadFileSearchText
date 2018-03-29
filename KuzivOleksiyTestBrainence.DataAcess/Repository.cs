using KuzivOleksiyTestBrainence.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KuzivOleksiyTestBrainence.DataAcess
{
  /// <summary>
  /// Abstraction for crud manipulation
  /// </summary>
  /// <typeparam name="T">entity for manipulation</typeparam>
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly TextContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(TextContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Adding new entity
    /// </summary>
    /// <param name="entity">new entity</param>
    public void Add(T entity)
    {
      _dbSet.Add(entity);
    }

    /// <summary>
    /// Removes entity by id
    /// </summary>
    /// <param name="id">id of entity to delete</param>
    public void Delete(Guid? id)
    {
      var entityToDelete = _dbSet.Find(id);
      Delete(entityToDelete);
    }

    /// <summary>
    /// Take items based on where condition
    /// </summary>
    /// <param name="where">where clause by which take items</param>
    /// <returns>list of items that specifies certain condition</returns>
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
    {
      return _dbSet.Where(where).ToList();
    }

    /// <summary>
    /// Take items based on where condition
    /// </summary>
    /// <param name="where">where clause by which take items</param>
    /// <returns>list of items that specifies certain condition</returns>
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include)
    {
      return _dbSet.Where(where).Include(include).ToList();
    }

    /// <summary>
    /// Take items based on where condition
    /// </summary>
    /// <param name="where">where clause by which take items</param>
    /// <returns>list of items that specifies certain condition</returns>
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2)
    {
      return _dbSet.Where(where).Include(include1).Include(include2).ToList();
    }

    /// <summary>
    /// Getting element with type T
    /// </summary>
    /// <param name="where">First or default element</param>
    /// <returns>Elememt T</returns>
    public T GetElement(Expression<Func<T, bool>> where)
    {
      return _dbSet.Where(where).FirstOrDefault();
    }

    ///// <summary>
    ///// Get element asynchronously with T param
    ///// </summary>
    ///// <param name="where">First or default element</param>
    ///// <returns></returns>
    //public async T GetElementAsync(Expression<Func<T, bool>> where)
    //{
    //   await _dbSet.Where(where).FirstOrDefaultAsync();
    //}

    public int GetCount(Expression<Func<T, bool>> where)
    {
      return _dbSet.Where(where).Count();
    }

    /// <summary>
    /// Getting element by id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>element</returns>
    public T GetById(Guid? id)
    {
      if (id != null)
      {
        return _dbSet.Find(id);
      }
      return null;
    }

    /// <summary>
    /// Updates entity
    /// </summary>
    /// <param name="entity">entity to update</param>
    public void Update(T entity)
    {
      _dbSet.Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }
    public bool Any(Expression<Func<T, bool>> where)
    {
      return _dbSet.Any(where);
    }
    /// <summary>
    /// Deletes entity
    /// </summary>
    /// <param name="entityToDelete">entity to delete</param>
    private void Delete(T entityToDelete)
    {
      if (_context.Entry(entityToDelete).State == EntityState.Detached)
      {
        _dbSet.Attach(entityToDelete);
      }
      _dbSet.Remove(entityToDelete);
    }
  }
}
