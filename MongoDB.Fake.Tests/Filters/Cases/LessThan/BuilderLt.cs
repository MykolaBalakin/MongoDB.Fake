using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThan
{
    internal class BuilderLt : LessThanTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Lt(d => d.IntField, 2);
        }
    }
}