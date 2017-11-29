using System.ComponentModel.DataAnnotations.Schema;

namespace IEnumerableVsIQueryable.CoreApp.Models
{
    [Table("LetterLanguageView")]
    public class LetterLanguageView
    {
        public long LetterId { get; set; }
        public string Letter { get; set; }
        public string Language { get; set; }
    }
}