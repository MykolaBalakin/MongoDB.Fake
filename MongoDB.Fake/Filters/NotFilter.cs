using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class NotFilter : IFilter
    {
        private readonly IFilter _child;

        public NotFilter(IFilter child)
        {
            _child = child;
        }

        public bool Filter(BsonValue value)
        {
            return !_child.Filter(value);
        }
    }
}
