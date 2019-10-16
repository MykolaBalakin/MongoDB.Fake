namespace MongoDB.Fake.Tests.Filters
{
    public class InFilterTests : FilterTestBase<InFilterTests, SimpleTestDocument>
    {
        public InFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}