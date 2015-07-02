using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableStackSerializer<TValue> : EnumerableSerializerBase<ImmutableStack<TValue>>
    {
        protected override void AddItem(object accumulator, object item)
            => ((Stack<TValue>) accumulator).Push((TValue) item);

        protected override object CreateAccumulator() => new Stack<TValue>();

        protected override IEnumerable EnumerateItemsInSerializationOrder(ImmutableStack<TValue> value)
            => value.Cast<object>().Reverse();

        protected override ImmutableStack<TValue> FinalizeResult(object accumulator)
            =>
                ((Stack<TValue>) accumulator)
                    .ToArray()
                    .Aggregate(ImmutableStack<TValue>.Empty, (stack, value) => stack.Push(value));
    }
}
