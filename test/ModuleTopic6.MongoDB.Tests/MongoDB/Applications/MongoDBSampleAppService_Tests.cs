using ModuleTopic6.MongoDB;
using ModuleTopic6.Samples;
using Xunit;

namespace ModuleTopic6.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<ModuleTopic6MongoDbTestModule>
{

}
