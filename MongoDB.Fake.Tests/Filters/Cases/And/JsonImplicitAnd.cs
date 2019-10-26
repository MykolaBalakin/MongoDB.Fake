using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class JsonImplicitAnd : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:2,StringField:\"string value\"}");
        }
    }
}