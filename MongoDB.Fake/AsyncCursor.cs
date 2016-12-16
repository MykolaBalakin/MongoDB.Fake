using System;
using System.Collections.Generic;
using System.Text;
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
                    throw new InvalidOperationException();
                }

                return _enumerable;
            }
        }

        public Boolean MoveNext(CancellationToken cancellationToken = default(CancellationToken))
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
                    throw new InvalidOperationException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Task<Boolean> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(MoveNext(cancellationToken));
        }

        public void Dispose()
        {
        }
    }
}
