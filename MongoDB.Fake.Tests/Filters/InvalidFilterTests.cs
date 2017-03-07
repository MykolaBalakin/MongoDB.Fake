using System;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests.Filters
{
    public class InvalidFilterTests
    {
        [Fact]
        public void UnsupportedOperatorThrowsNotSupportedException()
        {
            Test<NotSupportedException>("{IntField:{$unsupportedOperator:1}}");
        }

        [Fact]
        public void IncorrectAndFilterThrowsArgumentOutOfRangeException()
        {
            Test<ArgumentOutOfRangeException>("{$and:{}}");
        }

        private void Test<TException>(string json)
            where TException : Exception
        {
            var collection = new FakeMongoCollection<SimpleTestDocument>();

            var bson = BsonDocument.Parse(json);
            var filter = new BsonDocumentFilterDefinition<SimpleTestDocument>(bson);

            Action action = () => collection.Find(filter).ToList();
            action.ShouldThrow<TException>();
        }
    }
}
