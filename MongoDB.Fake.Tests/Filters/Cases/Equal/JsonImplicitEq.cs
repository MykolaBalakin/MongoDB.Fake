using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class JsonImplicitEq : EqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:1}");
        }
    }
}
