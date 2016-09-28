using System;
using System.Collections.Immutable;
using MongoDB.Bson.Serialization;
using MongoDB.Immutable.Serializer;
using NUnit.Framework;

namespace MongoDB.Immutable.SerializerTests
{
    [SetUpFixture]
    class Setup
    {
        public Setup()
        {
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableDictionary<,>),
                typeof(ImmutableDictionarySerializer<,>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableDictionary<,>),
                typeof(ImmutableDictionarySerializer<,>));

            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableList<>),
                typeof(ImmutableListSerializer<>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableList<>),
                typeof(ImmutableListSerializer<>));

            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableQueue<>),
                typeof(ImmutableQueueSerializer<>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableQueue<>),
                typeof(ImmutableQueueSerializer<>));

            BsonSerializer.RegisterGenericSerializerDefinition(typeof(IImmutableStack<>),
                typeof(ImmutableStackSerializer<>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableStack<>),
                typeof(ImmutableStackSerializer<>));

            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableHashSet<>),
                typeof(ImmutableHashSetSerializer<>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableSortedDictionary<,>),
                typeof(ImmutableSortedDictionarySerializer<,>));
            BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableSortedSet<>),
                typeof(ImmutableSortedSetSerializer<>));

        }
    }
}
