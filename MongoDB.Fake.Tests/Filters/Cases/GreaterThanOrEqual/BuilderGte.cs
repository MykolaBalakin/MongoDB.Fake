using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal class BuilderGte : GreaterThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Gte(d => d.IntField, 2);
        }
    }
}