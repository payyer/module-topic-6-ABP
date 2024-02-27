using Volo.Abp.Modularity;

namespace ModuleTopic6;

[DependsOn(
    typeof(ModuleTopic6ApplicationModule),
    typeof(ModuleTopic6DomainTestModule)
    )]
public class ModuleTopic6ApplicationTestModule : AbpModule
{

}
