namespace MongoDB.Fake.Tests.Filters
{
    public class LessThanOrEqualFilterTests : FilterTestBase<LessThanOrEqualFilterTests, SimpleTestDocument>
    {
        public LessThanOrEqualFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
