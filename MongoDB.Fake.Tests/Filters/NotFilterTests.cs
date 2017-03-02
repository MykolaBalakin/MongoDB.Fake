namespace MongoDB.Fake.Tests.Filters
{
    public class NotFilterTests : FilterTestBase<NotFilterTests, SimpleTestDocument>
    {
        public NotFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}