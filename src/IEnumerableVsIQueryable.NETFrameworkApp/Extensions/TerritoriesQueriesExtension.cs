using System.Data.Entity;
using System.Linq;

namespace IEnumerableVsIQueryable.NETFrameworkApp.Extensions
{
    public static class TerritoriesQueriesExtension
    {
        public static Region GetRegionByTerritoryIdWithFirstBefore(this IQueryable<Territories> source, string territoryId)
        {
            var result = source
                .Where(x => x.TerritoryID == territoryId)
                .Include(x => x.Region)
                .GroupBy(x => x.TerritoryID)
                .Select(x => x.First())
                .First()
                .Region;
            return result;
        }

        public static Region GetRegionByTerritoryIdWithFirstAfter(this IQueryable<Territories> source, string territoryId)
        {
            var result = source
                .Where(x => x.TerritoryID == territoryId)
                .Include(x => x.Region)
                .ToList()
                .GroupBy(x => x.TerritoryID)
                .Select(x => x.First())
                .First()
                .Region;
            return result;
        }
    }
}