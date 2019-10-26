using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class BuilderWhere : EqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Where(d => d.IntField == 1);
        }
    }
}
