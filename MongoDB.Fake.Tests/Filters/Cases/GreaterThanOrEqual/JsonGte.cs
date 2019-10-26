using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal class JsonGte : GreaterThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$gte:2}}");
        }
    }
}