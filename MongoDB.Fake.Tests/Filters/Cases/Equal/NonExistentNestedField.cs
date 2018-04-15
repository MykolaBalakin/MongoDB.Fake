using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class NonExistentNestedField : TestCaseBase, IFilterTestCase<EqualFilterTests, SimpleTestDocument>
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var filterDocument = BsonDocument.Parse("{IntField:{NonExistentNestedField:0}}");
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }

        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return new SimpleTestDocument[0];
        }
    }
}