using ModuleTopic6.Samples;
using Xunit;

namespace ModuleTopic6.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<ModuleTopic6MongoDbTestModule>
{

}
