using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    // ReSharper disable InconsistentNaming
    internal class IImmutableListSerializerTests : MongoIntegrationTest<IImmutableList<string>>
    {
        private static readonly IImmutableList<string> ExpectedList = ImmutableList<string>
            .Empty
            .Add("1")
            .Add("2");

        protected override TestDocument<IImmutableList<string>> CreateDocument()
        {
            return new TestDocument<IImmutableList<string>>(ExpectedList);
        }

        protected override IImmutableList<string> ExpectedResult() => ExpectedList;
    }

    internal class ImmutableListSerializerTests : MongoIntegrationTest<ImmutableList<string>>
    {
        private static readonly ImmutableList<string> ExpectedList = ImmutableList<string>
            .Empty
            .Add("1")
            .Add("2");

        protected override TestDocument<ImmutableList<string>> CreateDocument()
        {
            return new TestDocument<ImmutableList<string>>(ExpectedList);
        }

        protected override ImmutableList<string> ExpectedResult() => ExpectedList;
    }
}
