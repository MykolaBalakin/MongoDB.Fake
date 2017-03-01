using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Not
{
    internal class BuilderWhere : NotTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            return filterBuilder.Where(d => !(d.IntField == 3));
        }
    }
}