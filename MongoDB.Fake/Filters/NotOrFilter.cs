using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters
{
    internal class NotOrFilter : IFilter
    {
        private readonly IReadOnlyCollection<IFilter> _children;

        public NotOrFilter(IReadOnlyCollection<IFilter> children)
        {
            _children = children;
        }

        public Boolean Filter(BsonValue value)
        {
            return !_children.Any(filter => filter.Filter(value));
        }
    }
}