using System.Collections.Generic;

namespace MongoDB.Fake.Tests.Filters.Cases.Empty
{
    internal abstract class EmptyTestCaseBase : TestCaseBase, IFilterTestCase<EmptyFilterTests, SimpleTestDocument>
    {
        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return GetTestData();
        }
    }
}
