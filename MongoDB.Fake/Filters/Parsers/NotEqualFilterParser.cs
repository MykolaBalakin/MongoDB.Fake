using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class NotEqualFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new NotEqualFilter(filter);
        }
    }
}
