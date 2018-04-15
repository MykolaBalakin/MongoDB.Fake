using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Driver;
using Xunit;

namespace MongoDB.Fake.Tests
{
    public class FakeMongoCollectionTests : IClassFixture<MongoCollectionProviderFixture<SimpleTestDocument>>
    {
        private readonly MongoCollectionProviderFixture<SimpleTestDocument> _mongoCollectionProvider;

        public FakeMongoCollectionTests(MongoCollectionProviderFixture<SimpleTestDocument> mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        [Fact]
        public async Task FindReturnsDocuments()
        {
            var expectedDocuments = CreateTestData().ToList();

            var collection = CreateMongoCollection(nameof(FindReturnsDocuments));
            var cursor = await collection.FindAsync(d => true);
            var actualDocuments = cursor.ToList();

            actualDocuments.ShouldAllBeEquivalentTo(expectedDocuments);
        }

        [Fact]
        public async Task FindOneAndDeleteReturnsAndDeletesDocument()
        {
            var documentToDelete = CreateTestData().First();
            var expectedRemainedDocuments = CreateTestData().Skip(1).ToList();

            var collection = CreateMongoCollection(nameof(FindOneAndDeleteReturnsAndDeletesDocument));
            var actualDeletedDocument = await collection.FindOneAndDeleteAsync(d => d.Id == documentToDelete.Id);
            var remainedDocumets = collection.Find(d => true).ToList();

            actualDeletedDocument.ShouldBeEquivalentTo(documentToDelete);
            remainedDocumets.ShouldAllBeEquivalentTo(expectedRemainedDocuments);
        }

        [Fact]
        public async Task FindOneAndDeleteReturnsNullWhenNothingToDelete()
        {
            var expectedRemainedDocuments = CreateTestData().ToList();

            var collection = CreateMongoCollection(nameof(FindOneAndDeleteReturnsNullWhenNothingToDelete));
            // TODO: Replace filter to "d => false" when $type operator will be implemented
            var actualDeletedDocument = await collection.FindOneAndDeleteAsync(d => d.Id == Guid.Empty);
            var remainedDocumets = collection.Find(d => true).ToList();

            actualDeletedDocument.Should().BeNull();
            remainedDocumets.ShouldAllBeEquivalentTo(expectedRemainedDocuments);
        }

        [Fact]
        public async Task FindOneAndReplaceReturnsOldDocumentAndReplacesIt()
        {
            var documentToReplace = CreateTestData().First();
            var newDocument = CreateTestData().First();
            newDocument.IntField = 4;
            var expectedAllDocuments = CreateTestData().Skip(1)
                .Union(new[] { newDocument })
                .ToList();

            var collection = CreateMongoCollection(nameof(FindOneAndReplaceReturnsOldDocumentAndReplacesIt));
            var actualOldDocument = await collection.FindOneAndReplaceAsync(d => d.Id == documentToReplace.Id, newDocument);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualOldDocument.ShouldBeEquivalentTo(documentToReplace);
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task FindOneAndReplaceReturnsNullWhenNothingToReplace()
        {
            var newDocument = CreateTestData().First();
            newDocument.IntField = 4;
            var expectedAllDocuments = CreateTestData().ToList();

            var collection = CreateMongoCollection(nameof(FindOneAndReplaceReturnsOldDocumentAndReplacesIt));
            // TODO: Replace filter to "d => false" when $type operator will be implemented
            var actualOldDocument = await collection.FindOneAndReplaceAsync(d => d.Id == Guid.Empty, newDocument);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualOldDocument.Should().BeNull();
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task InsertOneInsertsDocument()
        {
            var newDocument = new SimpleTestDocument { Id = new Guid("00000000-0000-0000-0000-000000000004") };
            var expectedAllDocuments = CreateTestData()
                .Union(new[] { newDocument })
                .ToList();

            var collection = CreateMongoCollection(nameof(InsertOneInsertsDocument));
            await collection.InsertOneAsync(newDocument);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task InsertManyInsertsDocuments()
        {
            var newDocuments = new[]
            {
                new SimpleTestDocument { Id = new Guid("00000000-0000-0000-0000-000000000004") },
                new SimpleTestDocument { Id = new Guid("00000000-0000-0000-0000-000000000005") }
            };
            var expectedAllDocuments = CreateTestData()
                .Union(newDocuments)
                .ToList();

            var collection = CreateMongoCollection(nameof(InsertManyInsertsDocuments));
            await collection.InsertManyAsync(newDocuments);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task CountReturnsTotalCountWithEmptyFilter()
        {
            var expectedCount = CreateTestData().Count();

            var collection = CreateMongoCollection(nameof(CountReturnsTotalCountWithEmptyFilter));
            var actualCount = await collection.CountAsync(d => true);

            actualCount.Should().Be(expectedCount);
        }

        [Fact]
        public async Task CountReturnsActualCountWithFilter()
        {
            var expectedCount = CreateTestData().Count(d => d.IntField == 2);

            var collection = CreateMongoCollection(nameof(CountReturnsActualCountWithFilter));
            var actualCount = await collection.CountAsync(d => d.IntField == 2);

            actualCount.Should().Be(expectedCount);
        }

        [Fact]
        public async Task DeleteOneDeletesOneDocument()
        {
            var documentIdToDelete = new Guid("00000000-0000-0000-0000-000000000002");
            var expectedAllDocuments = CreateTestData()
                .Where(d => d.Id != documentIdToDelete)
                .ToList();
            var expectedResult = new DeleteResult.Acknowledged(1);

            var collection = CreateMongoCollection(nameof(DeleteOneDeletesOneDocument));
            var actualResult = await collection.DeleteOneAsync(d => d.Id == documentIdToDelete);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualResult.ShouldBeEquivalentTo(expectedResult);
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task DeleteOneDoesNothingWithFilter()
        {
            var expectedAllDocuments = CreateTestData().ToList();
            var expectedResult = new DeleteResult.Acknowledged(0);

            var collection = CreateMongoCollection(nameof(DeleteOneDoesNothingWithFilter));
            // TODO: Replace filter to "d => false" when $type operator will be implemented
            var actualResult = await collection.DeleteOneAsync(d => d.Id == Guid.Empty);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualResult.ShouldBeEquivalentTo(expectedResult);
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task DeleteManyDeletesDocuments()
        {
            var expectedAllDocuments = CreateTestData()
              .Where(d => d.IntField != 2)
              .ToList();
            var expectedResult = new DeleteResult.Acknowledged(2);

            var collection = CreateMongoCollection(nameof(DeleteManyDeletesDocuments));
            var actualResult = await collection.DeleteManyAsync(d => d.IntField == 2);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualResult.ShouldBeEquivalentTo(expectedResult);
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        [Fact]
        public async Task DeleteManyDoesNothingWithFilter()
        {
            var expectedAllDocuments = CreateTestData().ToList();
            var expectedResult = new DeleteResult.Acknowledged(0);

            var collection = CreateMongoCollection(nameof(DeleteManyDoesNothingWithFilter));
            // TODO: Replace filter to "d => false" when $type operator will be implemented
            var actualResult = await collection.DeleteManyAsync(d => d.Id == Guid.Empty);
            var actualAllDocuments = collection.Find(d => true).ToList();

            actualResult.ShouldBeEquivalentTo(expectedResult);
            actualAllDocuments.ShouldAllBeEquivalentTo(expectedAllDocuments);
        }

        private IMongoCollection<SimpleTestDocument> CreateMongoCollection(string collectionName)
        {
            var testData = CreateTestData();
            return _mongoCollectionProvider.GetCollection(collectionName, testData);
        }

        private IEnumerable<SimpleTestDocument> CreateTestData()
        {
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                IntField = 1
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                IntField = 2
            };
            yield return new SimpleTestDocument
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                IntField = 2
            };
        }
    }
}
