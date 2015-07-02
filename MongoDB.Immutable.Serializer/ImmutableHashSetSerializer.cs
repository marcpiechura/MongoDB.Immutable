using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableHashSetSerializer<TValue> : EnumerableSerializerBase<ImmutableHashSet<TValue>>
    {
        protected override void AddItem(object accumulator, object item)
            => ((HashSet<TValue>) accumulator).Add((TValue) item);

        protected override object CreateAccumulator() => new HashSet<TValue>();

        protected override IEnumerable EnumerateItemsInSerializationOrder(ImmutableHashSet<TValue> value) => value;

        protected override ImmutableHashSet<TValue> FinalizeResult(object accumulator)
            => ((HashSet<TValue>) accumulator).ToImmutableHashSet();
    }
}
