using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Empty
{
    internal class BuilderWhereTrue : EmptyTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Where(d => true);
        }
    }
}
