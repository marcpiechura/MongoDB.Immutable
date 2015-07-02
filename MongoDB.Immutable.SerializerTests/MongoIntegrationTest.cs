using System;
using Machine.Specifications;
using Mongo2Go;
using MongoDB.Driver;
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable StaticMemberInGenericType

namespace MongoDB.Immutable.SerializerTests
{
    class MongoIntegrationTest<TValue>
    {
        internal static MongoDbRunner _runner;
        internal static IMongoCollection<TestDocument<TValue>> Collection;

        private Establish context = () =>
        {
            _runner = MongoDbRunner.Start();

            Collection =
                new MongoClient(_runner.ConnectionString)
                    .GetDatabase("MongoDB-Immutable-Serializer")
                    .GetCollection<TestDocument<TValue>>("Test");
        };

        private Cleanup stuff = () =>
        {
            _runner.Dispose();
        };
    }
}
