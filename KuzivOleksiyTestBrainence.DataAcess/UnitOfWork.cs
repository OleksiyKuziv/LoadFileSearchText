using System;
using System.Threading.Tasks;
using KuzivOleksiyTestBrainence.Contracts;
using KuzivOlksiyTestBraincence_Models;


namespace KuzivOleksiyTestBrainence.DataAcess
{
  public class UnitOfWork :
 IDisposable,
 IUnitOfWork<Sentence>

    {
      private readonly TextContext _context = new TextContext();

      private Repository<Sentence> _sentece;
     

      IRepository<Sentence> IUnitOfWork<Sentence>.Repository
      {
        get
        {
        _sentece = _sentece ?? new Repository<Sentence>(_context);

          return _sentece;
        }
      }     

      public void Dispose()
      {
        _context.Dispose();
      }

      public void Save()
      {
        _context.SaveChanges();
      }

      public async Task SaveChangesAsync()
      {
        await _context.SaveChangesAsync();
      }
    }
  }
