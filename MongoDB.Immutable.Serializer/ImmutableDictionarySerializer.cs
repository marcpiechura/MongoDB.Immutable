using System.Collections.Immutable;

namespace MongoDB.Immutable.Serializer
{
    public class ImmutableDictionarySerializer<TKey, TValue> : ImmutableDictionarySerializerBase<ImmutableDictionary<TKey, TValue>, TKey, TValue>
    {
        protected override ImmutableDictionary<TKey, TValue> CreateInstance() => ImmutableDictionary<TKey, TValue>.Empty;
    }
}
