using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace ModuleTopic6.MongoDB;

[DependsOn(
    typeof(ModuleTopic6ApplicationTestModule),
    typeof(ModuleTopic6MongoDbModule)
)]
public class ModuleTopic6MongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
