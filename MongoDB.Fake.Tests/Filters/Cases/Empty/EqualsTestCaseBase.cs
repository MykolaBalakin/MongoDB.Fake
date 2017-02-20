using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Empty
{
    internal abstract class EmptyTestCaseBase : IFilterTestCase<EmptyFilterTests, SimpleTestDocument>
    {
        public abstract FilterDefinition<SimpleTestDocument> GetFilter();

        public IEnumerable<SimpleTestDocument> GetTestData()
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

        public IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return GetTestData();
        }
    }
}
