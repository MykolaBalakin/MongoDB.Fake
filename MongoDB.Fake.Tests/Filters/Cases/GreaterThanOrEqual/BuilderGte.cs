using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal class BuilderGte : GreaterThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Gte(d => d.IntField, 2);
        }
    }
}