using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThan
{
    internal class BuilderWhere : GreaterThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField > 2);
        }
    }
}