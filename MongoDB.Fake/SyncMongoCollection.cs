using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDB.Fake
{
    public abstract class SyncMongoCollection<TDocument> : IMongoCollection<TDocument>
    {
        public abstract CollectionNamespace CollectionNamespace { get; }
        public abstract IMongoDatabase Database { get; }
        public abstract IBsonSerializer<TDocument> DocumentSerializer { get; }
        public abstract IMongoIndexManager<TDocument> Indexes { get; }
        public abstract MongoCollectionSettings Settings { get; }

        public abstract IAsyncCursor<TProjection> FindSync<TProjection>(FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract TProjection FindOneAndDelete<TProjection>(FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract TProjection FindOneAndReplace<TProjection>(FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract TProjection FindOneAndUpdate<TProjection>(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract void InsertOne(TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract void InsertMany(IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract BulkWriteResult<TDocument> BulkWrite(IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract UpdateResult UpdateOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        public abstract UpdateResult UpdateMany(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract ReplaceOneResult ReplaceOne(FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract DeleteResult DeleteMany(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default(CancellationToken));
        public abstract DeleteResult DeleteMany(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken));
        public abstract DeleteResult DeleteOne(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default(CancellationToken));
        public abstract DeleteResult DeleteOne(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IAsyncCursor<TResult> Aggregate<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract long Count(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IAsyncCursor<TField> Distinct<TField>(FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IAsyncCursor<TResult> MapReduce<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default(CancellationToken));

        public abstract IFilteredMongoCollection<TDerivedDocument> OfType<TDerivedDocument>() where TDerivedDocument : TDocument;

        public abstract IMongoCollection<TDocument> WithReadConcern(ReadConcern readConcern);
        public abstract IMongoCollection<TDocument> WithReadPreference(ReadPreference readPreference);
        public abstract IMongoCollection<TDocument> WithWriteConcern(WriteConcern writeConcern);

        #region Async methods
        public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<TDocument> filter, FindOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(FindSync(filter, options, cancellationToken));
        }

        public Task<TProjection> FindOneAndDeleteAsync<TProjection>(FilterDefinition<TDocument> filter, FindOneAndDeleteOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(FindOneAndDelete(filter, options, cancellationToken));
        }

        public Task<TProjection> FindOneAndReplaceAsync<TProjection>(FilterDefinition<TDocument> filter, TDocument replacement, FindOneAndReplaceOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(FindOneAndReplace(filter, replacement, options, cancellationToken));
        }

        public Task<TProjection> FindOneAndUpdateAsync<TProjection>(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, FindOneAndUpdateOptions<TDocument, TProjection> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(FindOneAndUpdate(filter, update, options, cancellationToken));
        }

        public Task InsertOneAsync(TDocument document, CancellationToken cancellationToken)
        {
            InsertOne(document, cancellationToken: cancellationToken);
            return Task.CompletedTask;
        }

        public Task InsertOneAsync(TDocument document, InsertOneOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            InsertOne(document, options, cancellationToken);
            return Task.CompletedTask;
        }

        public Task InsertManyAsync(IEnumerable<TDocument> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            InsertMany(documents, options, cancellationToken);
            return Task.CompletedTask;
        }

        public Task<BulkWriteResult<TDocument>> BulkWriteAsync(IEnumerable<WriteModel<TDocument>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(BulkWrite(requests, options, cancellationToken));
        }

        public Task<UpdateResult> UpdateOneAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(UpdateOne(filter, update, options, cancellationToken));
        }

        public Task<UpdateResult> UpdateManyAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(UpdateMany(filter, update, options, cancellationToken));
        }

        public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<TDocument> filter, TDocument replacement, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(ReplaceOne(filter, replacement, options, cancellationToken));
        }

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(DeleteMany(filter, cancellationToken));
        }

        public Task<DeleteResult> DeleteManyAsync(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(DeleteMany(filter, options, cancellationToken));
        }

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(DeleteOne(filter, cancellationToken));
        }

        public Task<DeleteResult> DeleteOneAsync(FilterDefinition<TDocument> filter, DeleteOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(DeleteOne(filter, options, cancellationToken));
        }

        public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(PipelineDefinition<TDocument, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Aggregate(pipeline, options, cancellationToken));
        }

        public Task<long> CountAsync(FilterDefinition<TDocument> filter, CountOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Count(filter, options, cancellationToken));
        }

        public Task<IAsyncCursor<TField>> DistinctAsync<TField>(FieldDefinition<TDocument, TField> field, FilterDefinition<TDocument> filter, DistinctOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(Distinct(field, filter, options, cancellationToken));
        }

        public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<TDocument, TResult> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(MapReduce(map, reduce, options, cancellationToken));
        }
        #endregion
    }
}