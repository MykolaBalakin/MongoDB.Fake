using System;
using System.Collections.Generic;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests.Filters
{
    public class EmptyFilterTests
    {
        [Fact]
        public void FindReturnsAllDocumentsWithEmptyFilter()
        {
            var documentCollection = new BsonDocumentCollection();
            var testData = GetTestData();
            foreach (var document in testData)
            {
                var bsonDocument = document.ToBsonDocument();
                documentCollection.Add(bsonDocument);
            }

            var mongoCollection = new FakeMongoCollection<SimpleTestDocument>(documentCollection);

            var filter = FilterDefinition<SimpleTestDocument>.Empty;

            var actualResult = mongoCollection.FindSync(filter).ToList();
            var expectedResult = GetTestData();

            actualResult.ShouldAllBeEquivalentTo(expectedResult);
        }

        private IEnumerable<SimpleTestDocument> GetTestData()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1,
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                IntField = 2,
            };
        }
    }
}