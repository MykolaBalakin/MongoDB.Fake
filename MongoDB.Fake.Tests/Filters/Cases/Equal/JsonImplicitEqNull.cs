using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class JsonImplicitEqNull : EqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{StringField:null}");
        }
    }
}