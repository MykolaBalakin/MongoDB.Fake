using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThanOrEqual
{
    internal class BuilderLte : LessThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Lte(d => d.IntField, 2);
        }
    }
}