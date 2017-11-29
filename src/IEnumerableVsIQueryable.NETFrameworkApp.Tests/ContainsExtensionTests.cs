using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;
using Xunit;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Tests
{
    public class ContainsExtensionTests
    {
        [Fact]
        public void ContainsPureMethod()
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "ball" }, new Services { Name = "stick" } });

            // Act
            var result = source.ContainsByName("l");

            // Assert
            result.Should().NotBeEmpty().And.HaveCount(1).And.Contain(x => x.Name == "ball");
        }

        /// -- Region Parameters
        /// DECLARE @p0 NVarChar(1000) = '%m~%%'
        /// -- EndRegion
        /// SELECT [t0].[Id], [t0].[Name]
        /// FROM [TestsTable] AS [t0]
        /// WHERE [t0].[Name] LIKE @p0 ESCAPE '~'
        [Theory]
        [InlineData("M%")]
        [InlineData("M*")]
        public void Contains_With_Escape_Empty(string searchText)
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "My Service 1" } });

            // Act
            var result = source.ContainsByName(searchText);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void Contains_With_SqlMethodsLike_ThrowException()
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "My Service 1" } });

            // Act
            Exception ex = Assert.Throws<NotSupportedException>(() => source.ContainsByNameWithLike("m%"));

            // Assert
            ex.Message.Should().Be("Method 'Boolean Like(System.String, System.String)' cannot be used on the client; it is only for translation to SQL.");
        }
    }
}