using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ModuleTopic6;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ModuleTopic6DomainSharedModule)
)]
public class ModuleTopic6DomainModule : AbpModule
{

}
