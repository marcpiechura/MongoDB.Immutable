using System.Collections.Generic;
using System.Collections.Immutable;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableSortedSetSerializer<TValue> : EnumerableInterfaceImplementerSerializerBase<ImmutableSortedSet<TValue>>
    {
        protected override object CreateAccumulator() => new List<TValue>();

        protected override ImmutableSortedSet<TValue> FinalizeResult(object accumulator)
            => ((List<TValue>) accumulator).ToImmutableSortedSet();
    }
}
