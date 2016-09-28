using System.Collections.Immutable;
namespace MongoDB.Immutable.SerializerTests
{
    // ReSharper disable InconsistentNaming
    class IImmutableQueueSerializerTests : MongoIntegrationTest<IImmutableQueue<int>>
    {
        private static readonly IImmutableQueue<int> ExpectedQueue =
            ImmutableQueue<int>.Empty
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);

        protected override TestDocument<IImmutableQueue<int>> CreateDocument()
        {
            return new TestDocument<IImmutableQueue<int>>(ExpectedQueue);
        }

        protected override IImmutableQueue<int> ExpectedResult() => ExpectedQueue;
    }

    class ImmutableQueueSerializerTests : MongoIntegrationTest<ImmutableQueue<int>>
    {
        private static readonly ImmutableQueue<int> ExpectedQueue =
            ImmutableQueue<int>.Empty
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);

        protected override TestDocument<ImmutableQueue<int>> CreateDocument()
        {
            return new TestDocument<ImmutableQueue<int>>(ExpectedQueue);
        }

        protected override ImmutableQueue<int> ExpectedResult() => ExpectedQueue;
    }
}
