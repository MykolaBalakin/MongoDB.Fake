using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class InFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            if (!filter.IsBsonArray)
            {
                throw new ArgumentOutOfRangeException(nameof(filter));
            }

            var values = new ReadOnlyCollection<BsonValue>(filter.AsBsonArray);

            return new InFilter(values);
        }
    }
}