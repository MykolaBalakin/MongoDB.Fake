using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal interface IFilter
    {
        bool Filter(BsonValue value);
    }
}