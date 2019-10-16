using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDB.Fake
{
    public class AsyncCursor<T> : IAsyncCursor<T>
    {
        enum AsyncCursorState
        {
            New,
            Fetched,
            Finished
        }

        private readonly IEnumerable<T> _enumerable;
        private AsyncCursorState _state;

        public AsyncCursor(IEnumerable<T> enumerable)
        {
            _state = AsyncCursorState.New;
            _enumerable = enumerable;
        }

        public IEnumerable<T> Current
        {
            get
            {
                if (_state != AsyncCursorState.Fetched)
                {
                    throw new InvalidOperationException("MoveNext should be called first");
                }

                return _enumerable;
            }
        }

        public bool MoveNext(CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (_state)
            {
                case AsyncCursorState.New:
                    _state = AsyncCursorState.Fetched;
                    return true;
                case AsyncCursorState.Fetched:
                    _state = AsyncCursorState.Finished;
                    return false;
                case AsyncCursorState.Finished:
                    throw new InvalidOperationException("Cursor is already finished");
                default:
                    throw new InvalidOperationException("Unknown cursor state");
            }
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(MoveNext(cancellationToken));
        }

        public void Dispose()
        {
            // Noting to dispose but the method is required by the interface
        }
    }
}
