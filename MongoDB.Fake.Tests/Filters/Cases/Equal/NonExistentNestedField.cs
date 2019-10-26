using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class NonExistentNestedField : TestCaseBase, IFilterTestCase<EqualFilterTests, SimpleTestDocument>
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{IntField:{NonExistentNestedField:0}}");
        }

        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return new SimpleTestDocument[0];
        }
    }
}