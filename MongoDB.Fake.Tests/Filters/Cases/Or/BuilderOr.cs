using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Or
{
    internal class BuilderOr : OrTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Or(
                FilterBuilder.Where(d => d.IntField == 1),
                FilterBuilder.Where(d => d.StringField == "another value")
            );
        }
    }
}
