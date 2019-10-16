using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal class BuilderIn : InTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var values = new[] { 0, 1, 2 };
            return FilterBuilder.In(d => d.IntField, values);
        }
    }
}