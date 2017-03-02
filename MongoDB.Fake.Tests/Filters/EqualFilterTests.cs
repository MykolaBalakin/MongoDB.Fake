namespace MongoDB.Fake.Tests.Filters
{
    public class EqualFilterTests : FilterTestBase<EqualFilterTests, SimpleTestDocument>
    {
        public EqualFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
