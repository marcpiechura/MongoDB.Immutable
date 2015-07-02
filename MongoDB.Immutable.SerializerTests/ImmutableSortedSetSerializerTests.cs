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
    internal class ImmutableSortedSetSerializerTests : MongoIntegrationTest<ImmutableSortedSet<string>>
    {
        private static readonly ImmutableSortedSet<string> ExpectedSet = ImmutableSortedSet<string>
            .Empty
            .Add("1")
            .Add("2");

        private static ImmutableSortedSet<string> ActualSet;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableSortedSet<>), typeof(ImmutableSortedSetSerializer<>));

            Collection.InsertOneAsync(new TestDocument<ImmutableSortedSet<string>>(ExpectedSet)).Wait();
        };

        private Because of = () => ActualSet = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_sorted_list =
            () => ActualSet.ShouldAllBeEquivalentTo(ExpectedSet);
    }
}
