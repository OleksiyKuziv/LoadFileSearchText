using System;
using System.Threading.Tasks;

namespace KuzivOleksiyTestBrainence.Contracts
{
  public interface IUnitOfWork<T>:IDisposable
  {
    /// <summary>
    /// Repository for T entity
    /// </summary>
    IRepository<T> Repository { get; }
    /// <summary>
    /// Saves context
    /// </summary>
    void Save();
    Task SaveChangesAsync();
  }
}
