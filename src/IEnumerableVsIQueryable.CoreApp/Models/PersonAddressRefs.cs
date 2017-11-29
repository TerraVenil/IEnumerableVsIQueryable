namespace IEnumerableVsIQueryable.CoreApp.Models
{
    public partial class PersonAddressRefs
    {
        public int PersonId { get; set; }
        public int AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Persons Person { get; set; }
    }
}
