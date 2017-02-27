using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThen
{
    internal class BuilderWhere : LessThenTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField < 2);
        }
    }
}