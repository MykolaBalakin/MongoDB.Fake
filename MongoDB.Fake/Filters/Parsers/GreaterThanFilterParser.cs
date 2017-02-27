using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class GreaterThanFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new GreaterThanFilter(filter);
        }
    }
}
