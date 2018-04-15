using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class LessThanOrEqualFilter : IFilter
    {
        private readonly BsonValue _specifiedValue;

        public LessThanOrEqualFilter(BsonValue specifiedValue)
        {
            _specifiedValue = specifiedValue;
        }

        public bool Filter(BsonValue value)
        {
            return value.CompareTo(_specifiedValue) <= 0;
        }
    }
}