using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotIn
{
    internal class JsonNotInComplex : NotInTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{ Child: { $nin: [ { StringField: \"child string value\", IntField: 20 }, null ] } }");
        }
    }
}