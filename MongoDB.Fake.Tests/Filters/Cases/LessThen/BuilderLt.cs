using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThen
{
    internal class BuilderLt : LessThenTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Lt(d => d.IntField, 2);
        }
    }
}