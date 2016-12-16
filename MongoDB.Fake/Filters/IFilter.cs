using System;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal interface IFilter
    {
        Boolean Filter(BsonValue value);
    }
}