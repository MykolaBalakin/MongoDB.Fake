using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThanOrEqual
{
    internal class BuilderWhere : LessThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField <= 2);
        }
    }
}