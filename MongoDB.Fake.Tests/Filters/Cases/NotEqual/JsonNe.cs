using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotEqual
{
    internal class JsonNe : NotEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$ne:2}}");
        }
    }
}
