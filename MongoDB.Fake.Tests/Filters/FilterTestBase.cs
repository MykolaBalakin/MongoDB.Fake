using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests.Filters
{
    public abstract class FilterTestBase<TFilter, TDocument>
        where TFilter : FilterTestBase<TFilter, TDocument>
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            var assembly = typeof(FilterTestBase<,>).GetTypeInfo().Assembly;
            var testCaseInterface = typeof(IFilterTestCase<TFilter, TDocument>);
            var testCaseTypes = assembly.GetTypes()
                .Where(t => !t.GetTypeInfo().IsAbstract)
                .Where(t => testCaseInterface.IsAssignableFrom(t));
            var testCases = testCaseTypes
                .Select(Activator.CreateInstance)
                .Cast<IFilterTestCase<TFilter, TDocument>>();
            return testCases.Select(CreateTestParameters);
        }

        private static object[] CreateTestParameters(IFilterTestCase<TFilter, TDocument> testCase)
        {
            return new object[] { testCase };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void Test(IFilterTestCase<TFilter, TDocument> testCase)
        {
            this.Should().BeOfType<TFilter>();

            var collection = CreateMongoCollection(testCase);

            var filter = testCase.GetFilter();
            var actualResult = collection.Find(filter).ToList();
            var expectedResult = testCase.GetExpectedResult().ToList();

            var filterDescription = GetFilterDescription(filter);
            actualResult.ShouldBeEquivalentTo(expectedResult, because: "filter = {0}", becauseArgs: filterDescription);
        }

        private IMongoCollection<TDocument> CreateMongoCollection(IFilterTestCase<TDocument> testCase)
        {
            return CreateFakeMongoCollection(testCase);
        }

        private IMongoCollection<TDocument> CreateFakeMongoCollection(IFilterTestCase<TDocument> testCase)
        {
            var documentCollection = new BsonDocumentCollection();
            var testData = testCase.GetTestData();
            foreach (var document in testData)
            {
                var bsonDocument = document.ToBsonDocument();
                documentCollection.Add(bsonDocument);
            }

            var mongoCollection = new FakeMongoCollection<TDocument>(documentCollection);
            return mongoCollection;
        }

        private string GetFilterDescription(FilterDefinition<TDocument> filter)
        {
            if (filter is BsonDocumentFilterDefinition<TDocument> bsonFilter)
            {
                var json = bsonFilter.Document.ToJson();
                return "json: " + json;
            }

            if (filter is ExpressionFilterDefinition<TDocument> expressionFilter)
            {
                var expression = expressionFilter.Expression;
                return "expression: " + expression;
            }

            return filter.ToString();
        }
    }
}
