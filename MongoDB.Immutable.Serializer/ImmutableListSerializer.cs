using System.Collections.Generic;
using System.Collections.Immutable;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableListSerializer<TValue> : EnumerableInterfaceImplementerSerializerBase<ImmutableList<TValue>>
    {
        protected override object CreateAccumulator() => new List<TValue>();

        protected override ImmutableList<TValue> FinalizeResult(object accumulator)
            => ((List<TValue>) accumulator).ToImmutableList();
    }
}
