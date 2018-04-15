namespace MongoDB.Fake.Tests.Filters
{
    public class GreaterThanOrEqualFilterTests : FilterTestBase<GreaterThanOrEqualFilterTests, SimpleTestDocument>
    {
        public GreaterThanOrEqualFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
