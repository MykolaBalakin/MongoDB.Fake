using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Or
{
    internal class BuilderWhere : OrTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return FilterBuilder.Where(d => d.IntField == 1 || d.StringField == "another value");
        }
    }
}
