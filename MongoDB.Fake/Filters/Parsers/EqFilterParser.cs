using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class EqFilterParser : IFilterParser
    {
        public IFilter Parse(BsonValue filter)
        {
            return new EqFilter(filter);
        }
    }
}
