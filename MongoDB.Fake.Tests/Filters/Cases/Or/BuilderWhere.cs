using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Or
{
    internal class BuilderWhere : OrTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField == 1 || d.StringField == "another value");
        }
    }
}
