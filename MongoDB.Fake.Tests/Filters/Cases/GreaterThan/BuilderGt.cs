using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThan
{
    internal class BuilderGt : GreaterThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Gt(d => d.IntField, 2);
        }
    }
}