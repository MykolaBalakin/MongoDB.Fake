namespace MongoDB.Fake.Tests.Filters
{
    public class EmptyFilterTests : FilterTestBase<EmptyFilterTests, SimpleTestDocument>
    {
        public EmptyFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
