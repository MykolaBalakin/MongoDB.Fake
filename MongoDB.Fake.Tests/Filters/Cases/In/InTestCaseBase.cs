using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal abstract class InTestCaseBase : TestCaseBase, IFilterTestCase<InFilterTests, SimpleTestDocument>
    {
        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return GetTestData().Where(d =>
                d.Id == new Guid("00000000-0000-0000-0000-000000000001") ||
                d.Id == new Guid("00000000-0000-0000-0000-000000000002"));
        }
    }
}