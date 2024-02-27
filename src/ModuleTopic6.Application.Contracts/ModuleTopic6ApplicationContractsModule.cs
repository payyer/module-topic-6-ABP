using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ModuleTopic6;

[DependsOn(
    typeof(ModuleTopic6DomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ModuleTopic6ApplicationContractsModule : AbpModule
{

}
