using System.Collections.Generic;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class NotOrFilterParser : AggregatorFilterParserBase
    {
        public NotOrFilterParser(IFilterParser rootFilterParser)
            : base(rootFilterParser)
        {
        }

        protected override IFilter CreateFilter(IReadOnlyCollection<IFilter> childrenFilters)
        {
            return new NotOrFilter(childrenFilters);
        }
    }
}
