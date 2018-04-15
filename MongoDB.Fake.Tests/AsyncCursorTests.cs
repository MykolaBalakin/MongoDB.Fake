using System;
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

            Action action = () =>
            {
                var c = cursor.Current;
            };

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void CurrentReturnsDataAfterMoveNext()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            cursor.MoveNext().Should().BeTrue();
            cursor.Current.Should().BeSameAs(data);
        }

        [Fact]
        public void MoveNextReturnsFalseAfterDataEnds()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            cursor.MoveNext().Should().BeTrue();
            cursor.MoveNext().Should().BeFalse();
        }

        [Fact]
        public void MoveNextThrowsExceptionAfterEnumerationFinishes()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            cursor.MoveNext();
            cursor.MoveNext();

            Action action = () => cursor.MoveNext();

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public async Task CurrentReturnsDataAfterMoveNextAsync()
        {
            var data = new[] { 1 };
            var cursor = new AsyncCursor<Int32>(data);

            var moveNextResult = await cursor.MoveNextAsync();
            moveNextResult.Should().BeTrue();
            cursor.Current.Should().BeSameAs(data);
        }
    }
}
