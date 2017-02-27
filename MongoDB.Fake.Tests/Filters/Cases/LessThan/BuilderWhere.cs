using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThan
{
    internal class BuilderWhere : LessThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField < 2);
        }
    }
}