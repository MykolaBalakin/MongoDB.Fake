using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Empty
{
    internal class BuilderEmpty : EmptyTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var builder = Builders<SimpleTestDocument>.Filter;
            return builder.Empty;
        }
    }
}
