using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class AndFilter : IFilter
    {
        private readonly ICollection<IFilter> _children;

        public AndFilter(ICollection<IFilter> children)
        {
            _children = children;
        }

        public Boolean Filter(BsonValue value)
        {
            return _children.All(filter => filter.Filter(value));
        }
    }
}