using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using IEnumerableVsIQueryable.NETFrameworkApp.Extensions;
using Xunit;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Tests
{
    public class GroupByExtensionTests
    {
        [Theory]
        [InlineData("02903")]
        public void GroupBy_BeforeFirst(string territoryId)
        {
            // Arrange
            var territories = new EnumerableQuery<Territories>(
                                  new List<Territories>
                                  {
                                      new Territories
                                      {
                                          TerritoryID = "02903",
                                          TerritoryDescription = "Providence",
                                          RegionID = 1,
                                          Region = new Region { RegionID = 1, RegionDescription = "Eastern" }
                                      }
                                  });

            // Act
            var result = territories.GetRegionByTerritoryIdWithFirstBefore(territoryId);

            // Assert
            result.ShouldBeEquivalentTo(new Region { RegionID = 1, RegionDescription = "Eastern" });
        }

        [Theory]
        [InlineData("02903")]
        public void GroupBy_AfterFirst(string territoryId)
        {
            // Arrange
            var territories = new EnumerableQuery<Territories>(
                                  new List<Territories>
                                  {
                                      new Territories
                                      {
                                          TerritoryID = "02903",
                                          TerritoryDescription = "Providence",
                                          RegionID = 1,
                                          Region = new Region { RegionID = 1, RegionDescription = "Eastern" }
                                      }
                                  });

            // Act
            var result = territories.GetRegionByTerritoryIdWithFirstAfter(territoryId);

            // Assert
            result.ShouldBeEquivalentTo(new Region { RegionID = 1, RegionDescription = "Eastern" });
        }
    }
}