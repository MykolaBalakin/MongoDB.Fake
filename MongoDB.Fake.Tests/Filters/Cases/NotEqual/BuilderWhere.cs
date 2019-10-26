using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotEqual
{
    internal class BuilderWhere : NotEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Where(d => d.IntField != 2);
        }
    }
}
