using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal interface IFilterParser
    {
       IFilter Parse(BsonDocument filter);
    }
}
