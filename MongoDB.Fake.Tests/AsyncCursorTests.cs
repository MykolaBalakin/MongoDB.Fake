using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MongoDB.Fake.Tests
{
    public class AsyncCursorTests
    {
        [Fact]
        public void CurrentThrowsExceptionBeforeMoveNext()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            using (cursor)
            {
                Func<IEnumerable<Int32>> func = () => cursor.Current;
                func.Should().Throw<InvalidOperationException>();
            }
        }

        [Fact]
        public void CurrentReturnsDataAfterMoveNext()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            using (cursor)
            {
                cursor.MoveNext().Should().BeTrue();
                cursor.Current.Should().BeSameAs(data);
            }
        }

        [Fact]
        public void MoveNextReturnsFalseAfterDataEnds()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            using (cursor)
            {
                cursor.MoveNext().Should().BeTrue();
                cursor.MoveNext().Should().BeFalse();
            }
        }

        [Fact]
        public void MoveNextThrowsExceptionAfterEnumerationFinishes()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            using (cursor)
            {
                cursor.MoveNext();
                cursor.MoveNext();

                Action action = () => cursor.MoveNext();

                action.Should().Throw<InvalidOperationException>();
            }
        }

        [Fact]
        public async Task CurrentReturnsDataAfterMoveNextAsync()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            using (cursor)
            {
                var moveNextResult = await cursor.MoveNextAsync();
                moveNextResult.Should().BeTrue();
                cursor.Current.Should().BeSameAs(data);
            }
        }
    }
}