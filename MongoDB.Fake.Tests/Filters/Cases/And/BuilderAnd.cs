using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class BuilderAnd : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.And(
                FilterBuilder.Where(d => d.IntField == 2),
                FilterBuilder.Where(d => d.StringField == "string value")
            );
        }
    }
}
