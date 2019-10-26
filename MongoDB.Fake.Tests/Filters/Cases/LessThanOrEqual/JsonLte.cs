using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThanOrEqual
{
    internal class JsonLte : LessThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$lte:2}}");
        }
    }
}