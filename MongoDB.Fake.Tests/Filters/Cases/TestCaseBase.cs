using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases
{
    internal abstract class TestCaseBase : IFilterTestCase<SimpleTestDocument>
    {
        public abstract FilterDefinition<SimpleTestDocument> GetFilter();
        public abstract IEnumerable<SimpleTestDocument> GetExpectedResult();

        public IEnumerable<SimpleTestDocument> GetTestData()
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
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                IntField = 3,
                StringField = "another value"
            };
        }
    }
}
