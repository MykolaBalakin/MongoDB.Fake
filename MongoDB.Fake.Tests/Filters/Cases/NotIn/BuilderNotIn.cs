using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotIn
{
    internal class BuilderNotIn : NotInTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var values = new[] { 0, 1, 2 };
            return FilterBuilder.Nin(d => d.IntField, values);
        }
    }
}