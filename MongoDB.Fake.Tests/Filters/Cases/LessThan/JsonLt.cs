using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThan
{
    internal class JsonLt : LessThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$lt:2}}");
        }
    }
}