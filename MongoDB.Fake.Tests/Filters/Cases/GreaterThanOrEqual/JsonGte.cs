using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal class JsonGte : GreaterThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{IntField:{$gte:2}}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}