using MongoDB.Bson;

namespace MongoDB.Immutable.SerializerTests
{
    internal class TestDocument<TValue>
    {
        public ObjectId Id { get; set; }

        public TValue Value { get; set; }

        public TestDocument(TValue value)
        {
            Value = value;
        }
    }
}