using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ModuleTopic6;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ModuleTopic6HttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ModuleTopic6ConsoleApiClientModule : AbpModule
{

}
