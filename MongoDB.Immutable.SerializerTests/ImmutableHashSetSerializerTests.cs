using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    internal class ImmutableHashSetSerializerTests : MongoIntegrationTest<ImmutableHashSet<string>>
    {
        private static readonly ImmutableHashSet<string> ExpectedHashSet = ImmutableHashSet<string>
            .Empty
            .Add("1")
            .Add("2");

        protected override TestDocument<ImmutableHashSet<string>> CreateDocument()
        {
            return new TestDocument<ImmutableHashSet<string>>(ExpectedHashSet);
        }

        protected override ImmutableHashSet<string> ExpectedResult() => ExpectedHashSet;
    }
}
