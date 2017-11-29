using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;
using Xunit;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Tests
{
    public class LetterLaguageViewQueriesExtensionTests
    {
        public static IEnumerable<object[]> GetLetterLanguageViewData
        {
            get
            {
                var source = new List<LetterLanguageView>
                    {
                        new LetterLanguageView { Letter = "A", Language = "Ukrainian" },
                        new LetterLanguageView { Letter = "A", Language = "English" },
                        new LetterLanguageView { Letter = "B", Language = "Ukrainian" },
                        new LetterLanguageView { Letter = "B", Language = "English" }
                    };

                var expectedResult = new List<LetterLanguageView>
                    {
                        new LetterLanguageView { Letter = "A", Language = "Ukrainian" },
                        new LetterLanguageView { Letter = "A", Language = "English" }
                    };

                yield return new object[] { source, expectedResult };
            }
        }

        [Theory]
        [MemberData(nameof(GetLetterLanguageViewData))]
        public void FilterByLetterTest(IEnumerable<LetterLanguageView> source, IEnumerable<LetterLanguageView> expectedResult)
        {
            // Arrange
            var letters = new EnumerableQuery<LetterLanguageView>(source);

            // Act
            var result = letters.FilterByLetter("A");

            // Assert
            result.ShouldAllBeEquivalentTo(expectedResult);
        }
    }
}