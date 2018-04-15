using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class TypeFilterParser : IFilterParser
    {
        private static readonly IReadOnlyDictionary<String, BsonType> TypeAliases = new Dictionary<String, BsonType>
        {
            ["double"] = BsonType.Double,
            ["string"] = BsonType.String,
            ["object"] = BsonType.Document,
            ["array"] = BsonType.Array,
            ["binData"] = BsonType.Binary,
            ["undefined"] = BsonType.Undefined,
            ["objectId"] = BsonType.ObjectId,
            ["bool"] = BsonType.Boolean,
            ["date"] = BsonType.DateTime,
            ["null"] = BsonType.Null,
            ["regex"] = BsonType.RegularExpression,
            ["javascript"] = BsonType.JavaScript,
            ["symbol"] = BsonType.Symbol,
            ["javascriptWithScope"] = BsonType.JavaScriptWithScope,
            ["int"] = BsonType.Int32,
            ["timestamp"] = BsonType.Timestamp,
            ["long"] = BsonType.Int64,
            ["decimal"] = BsonType.Decimal128,
            ["minKey"] = BsonType.MinKey,
            ["maxKey"] = BsonType.MaxKey
        };

        public IFilter Parse(BsonValue filter)
        {
            if (filter.IsBsonArray)
            {
                return new TypeFilter(filter.AsBsonArray.Select(ParseBsonType));
            }

            return new TypeFilter(ParseBsonType(filter));
        }

        private BsonType ParseBsonType(BsonValue bson)
        {
            if (bson.IsString)
            {
                return ParseBsonType(bson.AsString);
            }

            if (bson.IsInt32)
            {
                var byteValue = unchecked((byte) bson.AsInt32);
                return (BsonType) byteValue;
            }

            throw new InvalidOperationException("$type operator supports only int or string as type to filter by");
        }

        private BsonType ParseBsonType(string alias)
        {
            if (TypeAliases.TryGetValue(alias, out var type))
            {
                return type;
            }

            throw new ArgumentOutOfRangeException(nameof(alias), alias, "Unknown BSON type alias");
        }
    }
}