using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal class JsonInComplex : InTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{ Child: { $in: [ { StringField: \"child string value\", IntField: 20 }, null ] } }");
        }
    }
}