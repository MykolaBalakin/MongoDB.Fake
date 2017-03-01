using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class NotFilterParser : IFilterParser
    {
        private readonly IFilterParser _rootFilterParser;

        public NotFilterParser(IFilterParser rootFilterParser)
        {
            _rootFilterParser = rootFilterParser;
        }

        public IFilter Parse(BsonValue filter)
        {
            var childFilter = _rootFilterParser.Parse(filter);
            return new NotFilter(childFilter);
        }
    }
}
