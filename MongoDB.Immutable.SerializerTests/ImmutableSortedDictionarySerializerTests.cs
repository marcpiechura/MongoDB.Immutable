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
    internal class ImmutableSortedDictionarySerializerTests : MongoIntegrationTest<ImmutableSortedDictionary<string, object>>
    {
        private static readonly ImmutableSortedDictionary<string, object> ExpectedDictionary = ImmutableSortedDictionary
            <string, object>
            .Empty
            .Add("2", 2)
            .Add("1", 1);

        private static ImmutableSortedDictionary<string, object> ActualDictionary;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableSortedDictionary<,>), typeof(ImmutableSortedDictionarySerializer<,>));

            Collection.InsertOneAsync(new TestDocument<ImmutableSortedDictionary<string, object>>(ExpectedDictionary)).Wait();
        };

        private Because of = () => ActualDictionary = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_sorted_dictionary =
            () => ActualDictionary.ShouldAllBeEquivalentTo(ExpectedDictionary);
    }
}
