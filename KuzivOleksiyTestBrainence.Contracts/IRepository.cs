using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KuzivOleksiyTestBrainence.Contracts
{
  /// <summary>
  /// Abstraction for crud manipulation
  /// </summary>
  /// <typeparam name="T">entity for manipulation</typeparam>
  public interface IRepository<T>
  {
    /// <summary>
    /// Adding new entity
    /// </summary>
    /// <param name="entity">new entity</param>
    void Add(T entity);
    /// <summary>
    /// Getting all elements with type T
    /// </summary>
    /// <returns>All elements</returns>
    IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
    /// <summary>
    /// Getting all elements with type T and one include
    /// </summary>
    /// <returns>All elements</returns>
    IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include);
    /// <summary>
    /// Getting all elements with type T and two includes
    /// </summary>
    /// <returns>All elements</returns>
    IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> include1, Expression<Func<T, object>> include2);
    /// <summary>
    /// Getting element with type T
    /// </summary>
    /// <param name="where">First or default element</param>
    /// <returns>Elememt T</returns>
    T GetElement(Expression<Func<T, bool>> where);
    /// <summary>
    /// Return count of param T
    /// </summary>
    /// <param name="where">Conditions</param>
    /// <returns></returns>
    int GetCount(Expression<Func<T, bool>> where);
    /// <summary>
    /// Updates entity
    /// </summary>
    /// <param name="entity">entity to update</param>
    void Update(T entity);

    /// <summary>
    /// Removes entity by id
    /// </summary>
    /// <param name="id">id of entity to delete</param>
    void Delete(Guid? id);
    /// <summary>
    /// Getting element by id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>element</returns>
    T GetById(Guid? id);
    bool Any(Expression<Func<T, bool>> where);
  }
}
