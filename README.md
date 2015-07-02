# MongoDB.Immutable
Serializer for System.Collections.Immutable

You can install the package via [Nuget](https://www.nuget.org/packages/MongoDB.Immutable/1.0.0)

#### Register serializer
You can register the serializer via the BsonSerializer like this: 
>BsonSerializer.RegisterGenericSerializerDefinition(typeof(ImmutableHashSet<>), typeof(ImmutableHashSetSerializer<>));  

Every Immutable class has it's own seriliazer
- ImmutableDictionary -> ImmutableDictionarySerializer
- ImmutableHashSet -> ImmutableHashSetSerializer
- ImmutableList -> ImmutableListSerializer
- ImmutableQueue -> ImmutableQueueSerializer
- ImmutableSortedDictionary -> ImmutableSortedDictionarySerializer
- ImmutableSortedSet -> ImmutableSortedSetSerializer
- ImmutableStack -> ImmutableStackSerializer
