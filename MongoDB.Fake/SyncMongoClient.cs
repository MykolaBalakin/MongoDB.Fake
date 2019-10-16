using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

namespace MongoDB.Fake
{
    public abstract class SyncMongoClient : IMongoClient
    {
        public abstract ICluster Cluster { get; }
        public abstract MongoClientSettings Settings { get; }

        public abstract IMongoDatabase GetDatabase(string name, MongoDatabaseSettings settings = null);
        public abstract IAsyncCursor<BsonDocument> ListDatabases(CancellationToken cancellationToken = default(CancellationToken));
        public abstract void DropDatabase(string name, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IMongoClient WithReadConcern(ReadConcern readConcern);
        public abstract IMongoClient WithReadPreference(ReadPreference readPreference);
        public abstract IMongoClient WithWriteConcern(WriteConcern writeConcern);

        #region Async methods
        public Task DropDatabaseAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            DropDatabase(name, cancellationToken);
            return Task.CompletedTask;
        }

        public Task<IAsyncCursor<BsonDocument>> ListDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(ListDatabases(cancellationToken));
        }
        #endregion
    }
}