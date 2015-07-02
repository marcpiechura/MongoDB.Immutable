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
    class IImmutableStackSerializerTests : MongoIntegrationTest<IImmutableStack<int>>
    {
        private static readonly IImmutableStack<int> ExpectedStack = ImmutableStack<int>.Empty.Push(0).Push(1).Push(2);
        private static IImmutableStack<int> ActualStack;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableStack<>),
                typeof(ImmutableStackSerializer<>));
            Collection.InsertOneAsync(new TestDocument<IImmutableStack<int>>(ExpectedStack)).Wait();
        };

        private Because of = () => ActualStack = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_stack = () => ActualStack.ShouldBeEquivalentTo(ExpectedStack);
    }

    class ImmutableStackSerializerTests : MongoIntegrationTest<ImmutableStack<int>>
    {
        private static readonly ImmutableStack<int> ExpectedStack = ImmutableStack<int>.Empty.Push(0).Push(1).Push(2);
        private static ImmutableStack<int> ActualStack;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableStack<>),
                typeof(ImmutableStackSerializer<>));
            Collection.InsertOneAsync(new TestDocument<ImmutableStack<int>>(ExpectedStack)).Wait();
        };

        private Because of = () => ActualStack = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_stack = () => ActualStack.ShouldBeEquivalentTo(ExpectedStack);
    }
}
