using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal class InvalidJson : InTestCaseBase
    {
        public override bool ThrowsException => true;

        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$in:1}}");
        }
    }
}