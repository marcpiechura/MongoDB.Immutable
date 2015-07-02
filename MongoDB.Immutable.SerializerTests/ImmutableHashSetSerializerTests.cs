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
    internal class ImmutableHashSetSerializerTests : MongoIntegrationTest<ImmutableHashSet<string>>
    {
        private static readonly ImmutableHashSet<string> ExpectedHashSet = ImmutableHashSet<string>
            .Empty
            .Add("1")
            .Add("2");

        private static ImmutableHashSet<string> ActualHashSet;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableHashSet<>), typeof(ImmutableHashSetSerializer<>));

            Collection.InsertOneAsync(new TestDocument<ImmutableHashSet<string>>(ExpectedHashSet)).Wait();
        };

        private Because of = () => ActualHashSet = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_hash_set =
            () => ActualHashSet.ShouldAllBeEquivalentTo(ExpectedHashSet);
    }
}
