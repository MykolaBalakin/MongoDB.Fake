using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class GreaterThanOrEqualFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new GreaterThanOrEqualFilter(filter);
        }
    }
}