using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.LessThanOrEqual
{
    internal class JsonLte : LessThanOrEqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{IntField:{$lte:2}}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}