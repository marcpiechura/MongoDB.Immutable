using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    // ReSharper disable once InconsistentNaming
    internal class IImmutableDictionarySerializerTests : MongoIntegrationTest<IImmutableDictionary<string, object>>
    {
        private static readonly IImmutableDictionary<string, object> ExpectedDictionary = ImmutableDictionary<string, object>
            .Empty
            .Add("1", 1)
            .Add("2", 2);

        protected override TestDocument<IImmutableDictionary<string, object>> CreateDocument()
        {
            return new TestDocument<IImmutableDictionary<string, object>>(ExpectedDictionary);
        }

        protected override IImmutableDictionary<string, object> ExpectedResult() => ExpectedDictionary;
    }


    internal class ImmutableDictionarySerializerTests : MongoIntegrationTest<ImmutableDictionary<string, object>>
    {
        private static readonly ImmutableDictionary<string, object> ExpectedDictionary = ImmutableDictionary<string, object>
            .Empty
            .Add("1", 1)
            .Add("2", 2);

        protected override TestDocument<ImmutableDictionary<string, object>> CreateDocument()
        {
            return new TestDocument<ImmutableDictionary<string, object>>(ExpectedDictionary);
        }

        protected override ImmutableDictionary<string, object> ExpectedResult() => ExpectedDictionary;
    }
}
