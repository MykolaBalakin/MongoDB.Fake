using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDB.Fake.Filters
{
    internal class FilterParser : IFilterParser
    {
        public IFilter Parse(BsonDocument filter)
        {
            return ParseBsonDocument(filter);
        }

        private IFilter ParseBsonDocument(BsonDocument filter)
        {
            var filters = new List<IFilter>();

            foreach (var bsonElement in filter.Elements)
            {
                filters.Add(ParseBsonElement(bsonElement));
            }

            if (filters.Any())
            {
                return new AndFilter(filters);
            }
            return new EmptyFilter();
        }

        private IFilter ParseBsonElement(BsonElement element)
        {
            if (IsOperator(element.Name))
            {
                return ParseOperator(element);
            }
            return ParseFieldFilter(element);
        }

        private Boolean IsOperator(String s)
        {
            throw new NotImplementedException();
        }

        private IFilter ParseOperator(BsonElement element)
        {
            throw new NotImplementedException();
        }

        private IFilter ParseFieldFilter(BsonElement element)
        {
            throw new NotImplementedException();
        }
    }
}