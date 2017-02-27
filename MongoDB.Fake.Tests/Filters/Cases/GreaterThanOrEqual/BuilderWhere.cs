using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal class BuilderWhere : GreaterThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField >= 2);
        }
    }
}