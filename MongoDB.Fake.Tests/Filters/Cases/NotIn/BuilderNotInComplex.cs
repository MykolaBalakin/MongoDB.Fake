using MongoDB.Driver;

namespace MongoDB.Fake.Tests.Filters.Cases.NotIn
{
    internal class BuilderNotInComplex : NotInTestCaseBase
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

            return FilterBuilder.Nin(d => d.Child, values);
        }
    }
}