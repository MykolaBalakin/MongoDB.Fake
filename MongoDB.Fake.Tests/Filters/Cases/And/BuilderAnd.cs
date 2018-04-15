using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class BuilderAnd : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.And(
                filterBuilder.Where(d => d.IntField == 2),
                filterBuilder.Where(d => d.StringField == "string value")
            );
        }
    }
}
