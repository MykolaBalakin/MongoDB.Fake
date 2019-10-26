namespace MongoDB.Fake.Tests.Filters
{
    public class NotInFilterTests : FilterTestBase<NotInFilterTests, SimpleTestDocument>
    {
        public NotInFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}