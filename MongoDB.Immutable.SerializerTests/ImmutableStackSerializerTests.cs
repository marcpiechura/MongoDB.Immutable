using System.Collections.Immutable;

namespace MongoDB.Immutable.SerializerTests
{
    // ReSharper disable once InconsistentNaming
    class IImmutableStackSerializerTests : MongoIntegrationTest<IImmutableStack<int>>
    {
        private static readonly IImmutableStack<int> ExpectedStack = ImmutableStack<int>.Empty.Push(0).Push(1).Push(2);
        
        protected override TestDocument<IImmutableStack<int>> CreateDocument()
        {
            return new TestDocument<IImmutableStack<int>>(ExpectedStack);
        }

        protected override IImmutableStack<int> ExpectedResult() => ExpectedStack;
    }

    class ImmutableStackSerializerTests : MongoIntegrationTest<ImmutableStack<int>>
    {
        private static readonly ImmutableStack<int> ExpectedStack = ImmutableStack<int>.Empty.Push(0).Push(1).Push(2);

        protected override TestDocument<ImmutableStack<int>> CreateDocument()
        {
            return new TestDocument<ImmutableStack<int>>(ExpectedStack);
        }

        protected override ImmutableStack<int> ExpectedResult() => ExpectedStack;
    }
}
