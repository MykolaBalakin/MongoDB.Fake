using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotOr
{
    internal class JsonNor : NotOrTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{$nor:[{IntField:1},{StringField:\"another value\"}]}");
        }
    }
}