using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Not
{
    internal class BuilderNotGte : NotTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Not(filterBuilder.Gte(d => d.IntField, 3));
        }
    }
}