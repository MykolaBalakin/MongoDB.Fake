using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotIn
{
    internal class JsonNotIn : NotInTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{ IntField: { $nin: [ 0, 1, 2 ] } }");
        }
    }
}