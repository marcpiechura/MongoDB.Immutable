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
    internal class IImmutableDictionarySerializerTests : MongoIntegrationTest<IImmutableDictionary<string, object>>
    {
        private static readonly IImmutableDictionary<string, object> ExpectedDictionary = ImmutableDictionary<string, object>
            .Empty
            .Add("1", 1)
            .Add("2", 2);

        private static IImmutableDictionary<string, object> ActualDictionary;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableDictionary<,>), typeof(ImmutableDictionarySerializer<,>));

            Collection.InsertOneAsync(new TestDocument<IImmutableDictionary<string, object>>(ExpectedDictionary)).Wait();
        };

        private Because of = () => ActualDictionary = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_dictionary =
            () => ActualDictionary.ShouldAllBeEquivalentTo(ExpectedDictionary);
    }


    internal class ImmutableDictionarySerializerTests : MongoIntegrationTest<ImmutableDictionary<string, object>>
    {
        private static readonly ImmutableDictionary<string, object> ExpectedDictionary = ImmutableDictionary<string, object>
            .Empty
            .Add("1", 1)
            .Add("2", 2);

        private static ImmutableDictionary<string, object> ActualDictionary;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableDictionary<,>), typeof(ImmutableDictionarySerializer<,>));

            Collection.InsertOneAsync(new TestDocument<ImmutableDictionary<string, object>>(ExpectedDictionary)).Wait();
        };

        private Because of = () => ActualDictionary = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_dictionary =
            () => ActualDictionary.ShouldAllBeEquivalentTo(ExpectedDictionary);
    }
}
