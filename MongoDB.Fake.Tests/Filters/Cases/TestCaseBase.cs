using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases
{
    internal abstract class TestCaseBase : IFilterTestCase<SimpleTestDocument>
    {
        protected FilterDefinitionBuilder<SimpleTestDocument> FilterBuilder => Builders<SimpleTestDocument>.Filter;

        public virtual bool ThrowsException => false;
        public abstract FilterDefinition<SimpleTestDocument> GetFilter();
        public abstract IEnumerable<SimpleTestDocument> GetExpectedResult();

        public IEnumerable<SimpleTestDocument> GetTestData()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1,
                StringField = null,
                Child = null,
                ArrayField = null,
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                IntField = 2,
                StringField = "string value",
                Child = new SimpleTestDocument.ChildDocument
                {
                    IntField = 20,
                    StringField = "child string value"
                },
                ArrayField = new[] { "a", "b" },
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                IntField = 3,
                StringField = "another value",
                Child = new SimpleTestDocument.ChildDocument
                {
                    IntField = 30,
                    StringField = "child another value"
                },
                ArrayField = new[] { "b", "c" }
            };
        }

        protected FilterDefinition<SimpleTestDocument> JsonFilter(string json)
        {
            var filterDocument = BsonDocument.Parse(json);
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(filterDocument);
        }
    }
}