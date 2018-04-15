using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class BuilderWhere : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField == 2 && d.StringField == "string value");
        }
    }
}
