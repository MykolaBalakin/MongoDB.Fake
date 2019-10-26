using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Empty
{
    internal class BuilderEmpty : EmptyTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Empty;
        }
    }
}
