using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal class ArrayFieldEqualContains : InTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{ ArrayField: { $in: [ [ \"a\", \"b\" ] ] } }");
        }

        public override IEnumerable<SimpleTestDocument> GetExpectedResult()
        {
            return GetTestData().Where(d => d.Id == new Guid("00000000-0000-0000-0000-000000000002"));
        }
    }
}