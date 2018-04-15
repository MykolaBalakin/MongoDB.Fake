namespace MongoDB.Fake.Tests.Filters
{
    public class NotEqualFilterTests : FilterTestBase<NotEqualFilterTests, SimpleTestDocument>
    {
        public NotEqualFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}