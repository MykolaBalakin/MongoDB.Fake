using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class LessThanFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new LessThanFilter(filter);
        }
    }
}