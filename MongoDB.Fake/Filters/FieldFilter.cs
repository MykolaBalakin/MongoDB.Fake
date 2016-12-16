using System;
using System.Reflection;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class FieldFilter : IFilter
    {
        private readonly IFilter _child;

        public FieldFilter(IFilter child)
        {
            _child = child;
        }

        public Boolean Filter(BsonValue value)
        {
            var fieldValue = GetFieldValue(value);
            return _child.Filter(fieldValue);
        }

        private BsonValue GetFieldValue(BsonValue value)
        {
            throw new NotImplementedException();
        }
    }
}