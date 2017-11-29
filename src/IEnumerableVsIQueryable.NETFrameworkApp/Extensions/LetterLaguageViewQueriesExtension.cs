using System.Collections.Generic;
using System.Linq;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Extensions
{
    public static class LetterLaguageViewQueriesExtension
    {
        public static IEnumerable<LetterLanguageView> FilterByLetter(this IQueryable<LetterLanguageView> source, string letter)
        {
            return source.Where(x => x.Letter == letter).ToList();
        }
    }
}