using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using MongoDB.Bson;
using System.Threading;

namespace MongoDB.Fake
{
    public class FakeMongoDatabase : SyncMongoDatabase
    {
        private readonly ConcurrentDictionary<String, BsonDocumentCollection> _collections;

        public override IMongoClient Client
        {
            get { throw new NotImplementedException(); }
        }

        public override DatabaseNamespace DatabaseNamespace
        {
            get { throw new NotImplementedException(); }
        }

        public override MongoDatabaseSettings Settings
        {
            get { throw new NotImplementedException(); }
        }

        public FakeMongoDatabase()
        {
            _collections = new ConcurrentDictionary<String, BsonDocumentCollection>();
        }

        public override IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null)
        {
            var collection = _collections.GetOrAdd(name, key => new BsonDocumentCollection());
            return new FakeMongoCollection<TDocument>(collection);
        }

        public override void CreateCollection(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override void CreateView<TDocument, TResult>(string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override void DropCollection(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override void RenameCollection(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override IAsyncCursor<BsonDocument> ListCollections(ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override TResult RunCommand<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override IMongoDatabase WithReadConcern(ReadConcern readConcern)
        {
            throw new NotImplementedException();
        }

        public override IMongoDatabase WithReadPreference(ReadPreference readPreference)
        {
            throw new NotImplementedException();
        }

        public override IMongoDatabase WithWriteConcern(WriteConcern writeConcern)
        {
            throw new NotImplementedException();
        }
    }
}
