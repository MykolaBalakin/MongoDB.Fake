using System;
using System.Collections.Concurrent;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake
{
    public class FakeMongoDatabase : SyncMongoDatabase
    {
        private readonly FakeMongoClient _client;
        private readonly ConcurrentDictionary<String, BsonDocumentCollection> _collections;

        public override IMongoClient Client => _client;

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

        internal FakeMongoDatabase(FakeMongoClient client)
            :this()
        {
            _client = client;
        }

        public override IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null)
        {
            var collection = _collections.GetOrAdd(name, key => new BsonDocumentCollection());
            return new FakeMongoCollection<TDocument>(this, collection);
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
