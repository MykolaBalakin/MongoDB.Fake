namespace MongoDB.Fake.Tests.Filters
{
    public class OrFilterTests : FilterTestBase<OrFilterTests, SimpleTestDocument>
    {
        public OrFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
