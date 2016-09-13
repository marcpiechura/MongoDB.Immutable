using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableStackSerializer<TValue> : EnumerableSerializerBase<ImmutableStack<TValue>, TValue>
    {
        protected override void AddItem(object accumulator, TValue item)
            => ((Stack<TValue>) accumulator).Push(item);

        protected override object CreateAccumulator() => new Stack<TValue>();

        protected override IEnumerable<TValue> EnumerateItemsInSerializationOrder(ImmutableStack<TValue> value)
            => value.Reverse();

        protected override ImmutableStack<TValue> FinalizeResult(object accumulator)
            =>
                ((Stack<TValue>) accumulator)
                    .ToArray()
                    .Aggregate(ImmutableStack<TValue>.Empty, (stack, value) => stack.Push(value));
    }
}
