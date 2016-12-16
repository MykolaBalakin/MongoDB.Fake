using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class EmptyFilter : IFilter
    {
        public Boolean Filter(BsonValue value)
        {
            return true;
        }
    }
}
