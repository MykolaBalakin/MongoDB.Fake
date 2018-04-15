using System;
using System.Collections.Concurrent;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

namespace MongoDB.Fake
{
    public class FakeMongoClient : SyncMongoClient
    {
        private readonly ConcurrentDictionary<String, IMongoDatabase> _databases;

        public override ICluster Cluster
        {
            get { throw new NotImplementedException(); }
        }

        public override MongoClientSettings Settings
        {
            get { throw new NotImplementedException(); }
        }

        public FakeMongoClient()
        {
            _databases = new ConcurrentDictionary<String, IMongoDatabase>();
        }

        public override IMongoDatabase GetDatabase(string name, MongoDatabaseSettings settings = null)
        {
            return _databases.GetOrAdd(name, CreateDatabase);
        }

        public override IAsyncCursor<BsonDocument> ListDatabases(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override void DropDatabase(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public override IMongoClient WithReadConcern(ReadConcern readConcern)
        {
            throw new NotImplementedException();
        }

        public override IMongoClient WithReadPreference(ReadPreference readPreference)
        {
            throw new NotImplementedException();
        }

        public override IMongoClient WithWriteConcern(WriteConcern writeConcern)
        {
            throw new NotImplementedException();
        }

        private IMongoDatabase CreateDatabase(string name)
        {
            return new FakeMongoDatabase(this);
        }
    }
}
