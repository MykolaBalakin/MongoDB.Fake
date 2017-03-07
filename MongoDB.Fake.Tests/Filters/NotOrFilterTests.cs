namespace MongoDB.Fake.Tests.Filters
{
    public class NotOrFilterTests : FilterTestBase<NotOrFilterTests, SimpleTestDocument>
    {
        public NotOrFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
