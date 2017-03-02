namespace MongoDB.Fake.Tests.Filters
{
    public class AndFilterTests : FilterTestBase<AndFilterTests, SimpleTestDocument>
    {
        public AndFilterTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
            : base(mongoCollectionProvider)
        {
        }
    }
}
