using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDB.Fake.Filters.Parsers
{
    internal class OrFilterParser : IFilterParser
    {
        private readonly IFilterParser _rootFilterParser;

        public OrFilterParser(IFilterParser rootFilterParser)
        {
            _rootFilterParser = rootFilterParser;
        }

        public IFilter Parse(BsonValue filter)
        {
            if (!filter.IsBsonArray)
            {
                throw new ArgumentOutOfRangeException(nameof(filter));
            }

            var childrenFilters = new List<IFilter>();
            var filterStatements = filter.AsBsonArray;
            foreach (var filterStatement in filterStatements)
            {
                var childFilter = _rootFilterParser.Parse(filterStatement);
                childrenFilters.Add(childFilter);
            }

            return new OrFilter(childrenFilters);
        }
    }
}
