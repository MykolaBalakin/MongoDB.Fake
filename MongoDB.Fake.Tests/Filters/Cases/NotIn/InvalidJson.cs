using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotIn
{
    internal class InvalidJson : NotInTestCaseBase
    {
        public override bool ThrowsException => true;

        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{$nin:1}}");
        }
    }
}