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
    internal class IImmutableListSerializerTests : MongoIntegrationTest<IImmutableList<string>>
    {
        private static readonly IImmutableList<string> ExpectedList = ImmutableList<string>
            .Empty
            .Add("1")
            .Add("2");

        private static IImmutableList<string> ActualList;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableList<>), typeof(ImmutableListSerializer<>));

            Collection.InsertOneAsync(new TestDocument<IImmutableList<string>>(ExpectedList)).Wait();
        };

        private Because of = () => ActualList = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_list =
            () => ActualList.ShouldAllBeEquivalentTo(ExpectedList);
    }

    internal class ImmutableListSerializerTests : MongoIntegrationTest<ImmutableList<string>>
    {
        private static readonly ImmutableList<string> ExpectedList = ImmutableList<string>
            .Empty
            .Add("1")
            .Add("2");

        private static ImmutableList<string> ActualList;

        private Establish context = () =>
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableList<>), typeof(ImmutableListSerializer<>));

            Collection.InsertOneAsync(new TestDocument<ImmutableList<string>>(ExpectedList)).Wait();
        };

        private Because of = () => ActualList = Collection.Find(_ => true).FirstAsync().Result.Value;

        private It should_return_the_saved_list =
            () => ActualList.ShouldAllBeEquivalentTo(ExpectedList);
    }
}
