using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    public class InFilter : IFilter
    {
        private readonly IReadOnlyCollection<BsonValue> _values;

        public InFilter(IReadOnlyCollection<BsonValue> values)
        {
            _values = values;
        }

        public bool Filter(BsonValue value)
        {
            if (value.IsBsonArray)
            {
                return FilterArray(value.AsBsonArray);
            }

            return FilterScalar(value);
        }

        private bool FilterScalar(BsonValue value)
        {
            return _values.Any(v => v.Equals(value));
        }

        private bool FilterArray(BsonArray array)
        {
            foreach (var filterValue in _values)
            {
                if (filterValue.IsBsonArray)
                {
                    if (array.Equals(filterValue.AsBsonArray))
                    {
                        return true;
                    }
                }
                else
                {
                    return array.Any(v => v.Equals(filterValue));
                }
            }

            return false;
        }
    }
}