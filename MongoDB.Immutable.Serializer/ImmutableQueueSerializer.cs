using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableQueueSerializer<TValue> : EnumerableSerializerBase<ImmutableQueue<TValue>, TValue>
    {
        protected override void AddItem(object accumulator, TValue item)
            => ((Queue<TValue>) accumulator).Enqueue(item);

        protected override object CreateAccumulator() => new Queue<TValue>();

        protected override IEnumerable<TValue> EnumerateItemsInSerializationOrder(ImmutableQueue<TValue> value)
            => value;

        protected override ImmutableQueue<TValue> FinalizeResult(object accumulator)
            =>
                ((Queue<TValue>) accumulator)
                    .ToArray()
                    .Aggregate(ImmutableQueue<TValue>.Empty, (stack, value) => stack.Enqueue(value));
    }
}
