using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equals
{
    internal abstract class EqualsTestCaseBase : IFilterTestCase<EqualsFilterTests, SimpleTestDocument>
    {
        public abstract FilterDefinition<SimpleTestDocument> GetFilter();

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
        }

        public IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1,
                StringField = null
            };
        }
    }
}
