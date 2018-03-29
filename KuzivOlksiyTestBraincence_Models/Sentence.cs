using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuzivOlksiyTestBraincence_Models
{
  public class Sentence
  {
    #region Public Property
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string SearchWord { get; set; }
    public string Date { get; set; }
    public string Text { get; set; }
    #endregion

    #region Public Constructors
    public Sentence() { }
    #endregion

  }
}
