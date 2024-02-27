using Volo.Abp.Modularity;

namespace ModuleTopic6;

[DependsOn(
    typeof(ModuleTopic6DomainModule),
    typeof(ModuleTopic6TestBaseModule)
)]
public class ModuleTopic6DomainTestModule : AbpModule
{

}
