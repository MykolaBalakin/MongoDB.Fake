using System.Collections.Generic;
using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters
{
    public interface IFilterTestCase<TDocument>
    {
        bool ThrowsException { get; }
        FilterDefinition<TDocument> GetFilter();
        IEnumerable<TDocument> GetTestData();
        IEnumerable<TDocument> GetExpectedResult();
    }

    public interface IFilterTestCase<TFilter, TDocument> : IFilterTestCase<TDocument>
        where TFilter : FilterTestBase<TFilter, TDocument>
    {
    }
}
