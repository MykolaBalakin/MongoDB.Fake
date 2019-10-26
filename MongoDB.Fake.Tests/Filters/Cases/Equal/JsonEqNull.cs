using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.Equal
{
    internal class JsonEqNull : EqualTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            return JsonFilter("{StringField:{$eq:null}}");
        }
    }
}
