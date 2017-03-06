using System.Collections.Generic;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class OrFilterParser : AggregatorFilterParserBase
    {
        public OrFilterParser(IFilterParser rootFilterParser)
            : base(rootFilterParser)
        {
        }

        protected override IFilter CreateFilter(IReadOnlyCollection<IFilter> childrenFilters)
        {
            return new OrFilter(childrenFilters);
        }
    }
}
