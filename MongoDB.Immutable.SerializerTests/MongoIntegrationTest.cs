using System.Collections;
using FluentAssertions;
using Mongo2Go;
using MongoDB.Driver;
using NUnit.Framework;

namespace MongoDB.Immutable.SerializerTests
{
    abstract class MongoIntegrationTest<TValue> where TValue : IEnumerable
    {
        private MongoDbRunner _runner;
        private IMongoCollection<TestDocument<TValue>> _collection;

        [OneTimeSetUp]
        public void Setup()
        {
            _runner = MongoDbRunner.Start();

            _collection =
                new MongoClient(_runner.ConnectionString)
                    .GetDatabase("MongoDB-Immutable-Serializer")
                    .GetCollection<TestDocument<TValue>>("Test");
        }

        protected abstract TestDocument<TValue> CreateDocument();

        protected abstract TValue ExpectedResult();

        [Test]
        public void Serializer_should_be_able_to_serialize()
        {
            _collection.InsertOne(CreateDocument());

            _collection.Find(_ => true).First().Value.ShouldBeEquivalentTo(ExpectedResult());
        }

        [OneTimeTearDown]
        public void Cleanup() => _runner.Dispose();
    }
}
