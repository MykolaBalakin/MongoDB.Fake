using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotEqual
{
    internal class BuilderWhere : NotEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField != 2);
        }
    }
}
