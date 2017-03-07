using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Fake.Tests.Filters.Cases.NotOr
{
    internal abstract class NotOrTestCaseBase : TestCaseBase, IFilterTestCase<NotOrFilterTests, SimpleTestDocument>
    {
        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return GetTestData().Where(d => d.Id== new Guid("00000000-0000-0000-0000-000000000002"));
        }
    }
}
