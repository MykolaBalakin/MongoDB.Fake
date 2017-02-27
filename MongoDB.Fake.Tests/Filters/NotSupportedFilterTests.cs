using System;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests.Filters
{
    public class NotSupportedFilterTests
    {
        [Fact]
        public void Test()
        {
            var collection = new FakeMongoCollection<SimpleTestDocument>();

            var bson = BsonDocument.Parse("{IntField:{$unsupportedOperator:1}}");
            var filter = new BsonDocumentFilterDefinition<SimpleTestDocument>(bson);

            Action action = () => collection.Find(filter).ToList();
            action.ShouldThrow<NotSupportedException>();
        }
    }
}
