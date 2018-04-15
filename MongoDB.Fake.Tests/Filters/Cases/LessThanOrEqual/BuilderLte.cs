using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThanOrEqual
{
    internal class BuilderLte : LessThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Lte(d => d.IntField, 2);
        }
    }
}