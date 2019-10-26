using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Not
{
    internal class BuilderNotGte : NotTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Not(FilterBuilder.Gte(d => d.IntField, 3));
        }
    }
}