using System.Collections.Generic;

namespace IEnumerableVsIQueryable.CoreApp.Models
{
    public partial class Persons
    {
        public Persons()
        {
            PersonAddressRefs = new HashSet<PersonAddressRefs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonAddressRefs> PersonAddressRefs { get; set; }
    }
}
