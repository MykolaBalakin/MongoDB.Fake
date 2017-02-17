using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests.Filters
{
    public class EqualsFilterTests
    {
        [Fact]
        public void FindReturnsFilteredDocumentsWithEqFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            TestFilter(filterBuilder.Eq(d => d.IntField, 1));
        }

        [Fact]
        public void FindReturnsFilteredDocumentsWithExpressionFilter()
        {
            var filterBuilder = Builders<SimpleTestDocument>.Filter;
            TestFilter(filterBuilder.Where(d => d.IntField == 1));
        }

        [Theory]
        [InlineData("{IntField:1}")]
        [InlineData("{IntField:{$eq:1}}")]
        [InlineData("{StringField:null}")]
        [InlineData("{StringField:{$eq:null}}")]
        public void FindReturnsFilteredDocumentsWithJsonFilter(string filter)
        {
            TestFilter(FromJson(filter));
        }

        private FilterDefinition<SimpleTestDocument> FromJson(string json)
        {
            var bsonDocument = BsonDocument.Parse(json);
            return new BsonDocumentFilterDefinition<SimpleTestDocument>(bsonDocument);
        }

        private void TestFilter(FilterDefinition<SimpleTestDocument> filter)
        {
            var documentCollection = new BsonDocumentCollection();
            var testData = GetTestData();
            foreach (var document in testData)
            {
                var bsonDocument = document.ToBsonDocument();
                documentCollection.Add(bsonDocument);
            }

            var mongoCollection = new FakeMongoCollection<SimpleTestDocument>(documentCollection);

            var actualResult = mongoCollection.FindSync(filter).ToList();
            var expectedResult = GetExpectedResultData();

            actualResult.ShouldAllBeEquivalentTo(expectedResult);
        }

        private IEnumerable<SimpleTestDocument> GetTestData()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1,
                StringField = null
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                IntField = 2,
                StringField = "string value"
            };
        }

        private IEnumerable<SimpleTestDocument> GetExpectedResultData()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1,
            };
        }
    }
}
