using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class JsonAnd : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{$and:[{IntField:2},{StringField:\"string value\"}]}");
        }
    }
}