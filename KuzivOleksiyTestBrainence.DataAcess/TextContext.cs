using KuzivOlksiyTestBraincence_Models;
using System.Data.Entity;

namespace KuzivOleksiyTestBrainence.DataAcess
{
  public class TextContext:DbContext
    {
    #region Public Constructor
    public TextContext() : base("Local")
    { }
    #endregion

    #region Public Property
    public DbSet<Sentence> Sentences { get; set; }
    #endregion
  }
}
