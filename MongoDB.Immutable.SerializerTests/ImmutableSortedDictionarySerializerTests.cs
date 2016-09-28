using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    internal class ImmutableSortedDictionarySerializerTests : MongoIntegrationTest<ImmutableSortedDictionary<string, object>>
    {
        private static readonly ImmutableSortedDictionary<string, object> ExpectedDictionary = ImmutableSortedDictionary
            <string, object>
            .Empty
            .Add("2", 2)
            .Add("1", 1);

        protected override TestDocument<ImmutableSortedDictionary<string, object>> CreateDocument()
        {
            return new TestDocument<ImmutableSortedDictionary<string, object>>(ExpectedDictionary);
        }

        protected override ImmutableSortedDictionary<string, object> ExpectedResult() => ExpectedDictionary;
    }
}
