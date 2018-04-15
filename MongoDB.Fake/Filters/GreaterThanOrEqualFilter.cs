using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class GreaterThanOrEqualFilter : IFilter
    {
        private readonly BsonValue _specifiedValue;

        public GreaterThanOrEqualFilter(BsonValue specifiedValue)
        {
            _specifiedValue = specifiedValue;
        }

        public bool Filter(BsonValue value)
        {
            return value.CompareTo(_specifiedValue) >= 0;
        }
    }
}