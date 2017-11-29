using System.Collections.Generic;

namespace IEnumerableVsIQueryable.CoreApp.Models
{
    public partial class Language
    {
        public Language()
        {
            Letter = new HashSet<Letter>();
        }

        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Letter> Letter { get; set; }
    }
}
