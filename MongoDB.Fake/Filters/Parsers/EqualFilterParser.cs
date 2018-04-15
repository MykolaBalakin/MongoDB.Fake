using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class EqualFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new EqualFilter(filter);
        }
    }
}
