using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThan
{
    internal class BuilderGt : GreaterThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Gt(d => d.IntField, 2);
        }
    }
}