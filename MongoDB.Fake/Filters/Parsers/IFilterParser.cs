using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal interface IFilterParser
    {
       IFilter Parse(BsonValue filter);
    }
}
