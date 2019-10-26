using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class NotInFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            if (!filter.IsBsonArray)
            {
                throw new ArgumentOutOfRangeException(nameof(filter));
            }

            var values = new ReadOnlyCollection<BsonValue>(filter.AsBsonArray);

            var inFilter = new InFilter(values);
            return new NotFilter(inFilter);
        }
    }
}