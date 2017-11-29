namespace IEnumerableVsIQueryable.CoreApp.Models
{
    public partial class Letter
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}
