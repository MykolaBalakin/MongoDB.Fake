using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Fake.Tests.Filters.Cases.GreaterThanOrEqual
{
    internal abstract class GreaterThanOrEqualTestCaseBase : TestCaseBase, IFilterTestCase<GreaterThanOrEqualFilterTests, SimpleTestDocument>
    {
        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            var expectedResultIds = new[]
            {
                new Guid("00000000-0000-0000-0000-000000000002"),
                new Guid("00000000-0000-0000-0000-000000000003")
            };
            return GetTestData().Where(d => expectedResultIds.Contains(d.Id));
        }
    }
}
