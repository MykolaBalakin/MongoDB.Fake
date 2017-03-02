namespace MongoDB.Fake.Tests.Filters
{
    public class LessThanFilterTests : FilterTestBase<LessThanFilterTests, SimpleTestDocument>
    {
        public LessThanFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
