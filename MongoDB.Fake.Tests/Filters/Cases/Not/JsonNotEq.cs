using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Not
{
    internal class JsonNotEq : NotTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{IntField:{$not:{$eq:3}}}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}
