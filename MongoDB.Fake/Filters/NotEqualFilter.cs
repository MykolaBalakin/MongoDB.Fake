using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class NotEqualFilter : IFilter
    {
        private readonly BsonValue _specifiedValue;

        public NotEqualFilter(BsonValue specifiedValue)
        {
            _specifiedValue = specifiedValue;
        }

        public bool Filter(BsonValue value)
        {
            return !value.Equals(_specifiedValue);
        }
    }
}
