using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    internal class ImmutableSortedSetSerializerTests : MongoIntegrationTest<ImmutableSortedSet<string>>
    {
        private static readonly ImmutableSortedSet<string> ExpectedSet = ImmutableSortedSet<string>
            .Empty
            .Add("1")
            .Add("2");

        protected override TestDocument<ImmutableSortedSet<string>> CreateDocument()
        {
            return new TestDocument<ImmutableSortedSet<string>>(ExpectedSet);
        }

        protected override ImmutableSortedSet<string> ExpectedResult() => ExpectedSet;
    }
}
