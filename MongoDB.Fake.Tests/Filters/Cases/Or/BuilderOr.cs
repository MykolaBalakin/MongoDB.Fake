using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Or
{
    internal class BuilderOr : OrTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Or(
                filterBuilder.Where(d => d.IntField == 1),
                filterBuilder.Where(d => d.StringField == "another value")
            );
        }
    }
}
