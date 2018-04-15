using FluentAssertions;
using Xunit;

namespace MongoDB.Fake.Tests
{
    public class FakeMongoClientTests
    {
        [Fact]
        public void GetDatabaseReturnsDatabase()
        {
            var client = new FakeMongoClient();
            var database = client.GetDatabase("fake-database");

            database.Should().NotBeNull();
            database.Client.Should().BeSameAs(client);
        }
    }
}
