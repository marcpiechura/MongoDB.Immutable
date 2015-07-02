using System.Collections.Immutable;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableSortedDictionarySerializer<TKey, TValue> : ImmutableDictionarySerializerBase<ImmutableSortedDictionary<TKey, TValue>, TKey, TValue>
    {
        protected override ImmutableSortedDictionary<TKey, TValue> CreateInstance() => ImmutableSortedDictionary<TKey, TValue>.Empty;
    }
}
