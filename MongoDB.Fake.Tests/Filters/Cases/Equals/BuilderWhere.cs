using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equals
{
    internal class BuilderWhere : EqualsTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => d.IntField == 1);
        }
    }
}
