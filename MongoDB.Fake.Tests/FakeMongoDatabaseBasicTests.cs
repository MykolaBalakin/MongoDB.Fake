using FluentAssertions;
using MongoDB.Bson;
using Xunit;

namespace MongoDB.Fake.Tests
{
    public class FakeMongoDatabaseBasicTests
    {
        [Fact]
        public void GetCollectionReturnsCollection()
        {
            var database = new FakeMongoDatabase();
            var collection = database.GetCollection<BsonDocument>("fake-collection");

            collection.Should().NotBeNull();
        }
    }
}