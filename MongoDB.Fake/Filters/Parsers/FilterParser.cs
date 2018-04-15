using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class FilterParser : IFilterParser
    {
        private static readonly Lazy<IFilterParser> _instance = new Lazy<IFilterParser>(CreateFilterParser);
        public static IFilterParser Instance => _instance.Value;

        private static IFilterParser CreateFilterParser()
        {
            return new FilterParser();
        }

        private static IDictionary<string, IFilterParser> CreateOperatorParsers(IFilterParser rootParser)
        {
            var result = new Dictionary<string, IFilterParser>();

            result.Add(Operators.Eq, new EqualFilterParser());
            result.Add(Operators.Ne, new NotEqualFilterParser());
            result.Add(Operators.Gt, new GreaterThanFilterParser());
            result.Add(Operators.Gte, new GreaterThanOrEqualFilterParser());
            result.Add(Operators.Lt, new LessThanFilterParser());
            result.Add(Operators.Lte, new LessThanOrEqualFilterParser());

            result.Add(Operators.And, new AndFilterParser(rootParser));
            result.Add(Operators.Or, new OrFilterParser(rootParser));
            result.Add(Operators.Nor, new NotOrFilterParser(rootParser));
            result.Add(Operators.Not, new NotFilterParser(rootParser));

            result.Add(Operators.Type, new TypeFilterParser());

            return result;
        }


        private readonly IDictionary<string, IFilterParser> _operatorFilterParsers;

        private FilterParser()
        {
            _operatorFilterParsers = CreateOperatorParsers(this);
        }

        public IFilter Parse(BsonValue filter)
        {
            return ParseBson(filter);
        }

        private IFilter ParseBson(BsonValue bson)
        {
            if (bson.IsBsonDocument)
            {
                return ParseBsonDocument(bson.AsBsonDocument);
            }

            // Implicit $eq filter
            return ParseOperator(new BsonElement(Operators.Eq, bson));
        }

        private IFilter ParseBsonDocument(BsonDocument filter)
        {
            var filters = new List<IFilter>();

            // Implicit $and filter
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
            return s.StartsWith("$");
        }

        private IFilter ParseOperator(BsonElement element)
        {
            var operatorName = element.Name;
            if (!_operatorFilterParsers.ContainsKey(operatorName))
            {
                throw new NotSupportedException($"Operator \"{operatorName}\" not supported.");
            }
            return _operatorFilterParsers[operatorName].Parse(element.Value);
        }

        private IFilter ParseFieldFilter(BsonElement element)
        {
            var fieldName = element.Name;
            var childFilter = ParseBson(element.Value);
            return new FieldFilter(fieldName, childFilter);
        }
    }
}