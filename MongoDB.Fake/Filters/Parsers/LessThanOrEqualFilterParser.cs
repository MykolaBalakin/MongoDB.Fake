using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class LessThanOrEqualFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new LessThanOrEqualFilter(filter);
        }
    }
}