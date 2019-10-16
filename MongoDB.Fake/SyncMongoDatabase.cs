using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Fake
{
    public abstract class SyncMongoDatabase : IMongoDatabase
    {
        public abstract IMongoClient Client { get; }
        public abstract DatabaseNamespace DatabaseNamespace { get; }
        public abstract MongoDatabaseSettings Settings { get; }

        public abstract IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null);
        public abstract void CreateCollection(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void CreateView<TDocument, TResult>(string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void DropCollection(string name, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void RenameCollection(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract IAsyncCursor<BsonDocument> ListCollections(ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract TResult RunCommand<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IMongoDatabase WithReadConcern(ReadConcern readConcern);
        public abstract IMongoDatabase WithReadPreference(ReadPreference readPreference);
        public abstract IMongoDatabase WithWriteConcern(WriteConcern writeConcern);

        #region Async methods
        public Task CreateCollectionAsync(string name, CreateCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            CreateCollection(name, options, cancellationToken);
            return Task.CompletedTask;
        }

        public Task CreateViewAsync<TDocument, TResult>(string viewName, string viewOn, PipelineDefinition<TDocument, TResult> pipeline, CreateViewOptions<TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            CreateView(viewName, viewOn, pipeline, options, cancellationToken);
            return Task.CompletedTask;
        }

        public Task DropCollectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            DropCollection(name, cancellationToken);
            return Task.CompletedTask;
        }

        public Task RenameCollectionAsync(string oldName, string newName, RenameCollectionOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            RenameCollection(oldName, newName, options, cancellationToken);
            return Task.CompletedTask;
        }

        public Task<IAsyncCursor<BsonDocument>> ListCollectionsAsync(ListCollectionsOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(ListCollections(options, cancellationToken));
        }

        public Task<TResult> RunCommandAsync<TResult>(Command<TResult> command, ReadPreference readPreference = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(RunCommand(command, readPreference, cancellationToken));
        }
        #endregion
    }
}