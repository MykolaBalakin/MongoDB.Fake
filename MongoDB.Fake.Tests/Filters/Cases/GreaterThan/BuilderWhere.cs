using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThan
{
    internal class BuilderWhere : GreaterThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Where(d => d.IntField > 2);
        }
    }
}