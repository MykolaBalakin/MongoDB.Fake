using System.Collections.Generic;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class AndFilterParser : AggregatorFilterParserBase
    {
        public AndFilterParser(IFilterParser rootFilterParser)
            : base(rootFilterParser)
        {
        }

        protected override IFilter CreateFilter(IReadOnlyCollection<IFilter> childrenFilters)
        {
            return new AndFilter(childrenFilters);
        }
    }
}
