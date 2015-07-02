using System.Collections.Immutable;
using FluentAssertions;
using Machine.Specifications;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Immutable.Serializer;
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace MongoDB.Immutable.SerializerTests
{
    class IImmutableQueueSerializerTests : MongoIntegrationTest<IImmutableQueue<int>>
    {
        private static readonly IImmutableQueue<int> ExpectedQueue =
            ImmutableQueue<int>.Empty
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);

        private static IImmutableQueue<int> ActualQueue;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableQueue<>),
                typeof(ImmutableQueueSerializer<>));
            Collection.InsertOneAsync(new TestDocument<IImmutableQueue<int>>(ExpectedQueue)).Wait();
        };

        private Because of = () => ActualQueue = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_queue = () => ActualQueue.ShouldBeEquivalentTo(ExpectedQueue);
    }

    class ImmutableQueueSerializerTests : MongoIntegrationTest<ImmutableQueue<int>>
    {
        private static readonly ImmutableQueue<int> ExpectedQueue =
            ImmutableQueue<int>.Empty
                .Enqueue(1)
                .Enqueue(2)
                .Enqueue(3);

        private static ImmutableQueue<int> ActualQueue;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableQueue<>),
                typeof(ImmutableQueueSerializer<>));
            Collection.InsertOneAsync(new TestDocument<ImmutableQueue<int>>(ExpectedQueue)).Wait();
        };

        private Because of = () => ActualQueue = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_queue = () => ActualQueue.ShouldBeEquivalentTo(ExpectedQueue);
    }
}
