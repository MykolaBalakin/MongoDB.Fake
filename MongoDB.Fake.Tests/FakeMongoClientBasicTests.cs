using FluentAssertions;
using System;
using Xunit;

namespace MongoDB.Fake.Tests
{
    public class FakeMongoClientBasicTests
    {
        [Fact]
        public void GetDatabaseReturnsDatabase()
        {
            var client = new FakeMongoClient();
            var database = client.GetDatabase("fake-database");

            database.Should().NotBeNull();
        }
    }
}
