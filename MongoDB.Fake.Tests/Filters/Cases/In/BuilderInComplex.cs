using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.In
{
    internal class BuilderInComplex : InTestCaseBase
    {
        public override FilterDefinition<SimpleTestDocument> GetFilter()
        {
            var values = new[]
            {
                new SimpleTestDocument.ChildDocument
                {
                    IntField = 20,
                    StringField = "child string value"
                },
                null
            };

            return FilterBuilder.In(d => d.Child, values);
        }
    }
}