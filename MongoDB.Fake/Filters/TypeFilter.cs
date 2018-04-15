using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class TypeFilter : IFilter
    {
        private readonly IReadOnlyCollection<BsonType> _types;

        public TypeFilter(BsonType type)
        {
            _types = new HashSet<BsonType>
            {
                type
            };
        }

        public TypeFilter(IEnumerable<BsonType> types)
        {
            _types = new HashSet<BsonType>(types);
        }

        public bool Filter(BsonValue value)
        {
            return _types.Contains(value.BsonType);
        }
    }
}