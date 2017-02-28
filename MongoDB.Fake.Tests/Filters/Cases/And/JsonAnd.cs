using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.And
{
    internal class JsonAnd : AndTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{$and:[{IntField:2},{StringField:\"string value\"}]}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}