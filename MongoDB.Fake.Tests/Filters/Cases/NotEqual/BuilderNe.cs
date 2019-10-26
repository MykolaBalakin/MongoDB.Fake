using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotEqual
{
    internal class BuilderNe : NotEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Ne(d => d.IntField, 2);
        }
    }
}
