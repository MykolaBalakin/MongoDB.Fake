using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Not
{
    internal class JsonNotGt : NotTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{IntField:{$not:{$gt:2}}}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}