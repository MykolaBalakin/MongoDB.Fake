using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class EmptyFilter : IFilter
    {
        public bool Filter(BsonValue value)
        {
            return true;
        }
    }
}
