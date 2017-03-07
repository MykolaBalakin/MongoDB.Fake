using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Fake.Filters
{
    internal static class Operators
    {
        public const string Eq = "$eq";
        public const string Ne = "$ne";
        public const string Gt = "$gt";
        public const string Gte = "$gte";
        public const string Lt = "$lt";
        public const string Lte = "$lte";

        public const string And = "$and";
        public const string Or = "$or";
        public const string Nor = "$nor";
        public const string Not = "$not";
    }
}
