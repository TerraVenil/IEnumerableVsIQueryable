using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;
using Xunit;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Tests
{
    public class StartWithExtensionTests
    {
        /// -- Region Parameters
        /// DECLARE @p0 NVarChar(1000) = 'M%'
        /// -- EndRegion
        /// SELECT [t0].[Id], [t0].[Name]
        /// FROM [TestsTable] AS [t0]
        /// WHERE [t0].[Name] LIKE @p0
        [Theory]
        [InlineData("M")]
        public void StartWith_UpperCase_NotEmpty(string searchText)
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "My Service 1" }, new Services { Name = "Another Service 3" } });

            // Act
            var result = source.StartWith(searchText);

            // Assert
            result.Should().Be("My Service 1");
        }

        [Theory]
        [InlineData("m")]
        public void StartWith_LowerCase_Empty(string searchText)
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "My Service 1" } });

            // Act
            var result = source.StartWith(searchText);

            // Assert
            result.Should().BeNull();
        }

        /// -- Region Parameters
        /// DECLARE @p0 NVarChar(1000) = 'M%'
        /// DECLARE @p1 NVarChar(1000) = '%1'
        /// -- EndRegion
        /// SELECT [t0].[Id], [t0].[Name]
        /// FROM [TestsTable] AS [t0]
        /// WHERE ([t0].[Name] LIKE @p0) AND ([t0].[Name] LIKE @p1)
        public void StartWith_And_EndWith()
        {
            // Arrange
            var source = new EnumerableQuery<Services>(new List<Services> { new Services { Name = "My Service 1" } });

            // Act
            var result = source.Where(x => x.Name.StartsWith("M") && x.Name.EndsWith("1"));

            // Assert
            result.Should().BeEmpty();
        }
    }
}