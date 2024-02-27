using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace ModuleTopic6.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(ModuleTopic6BlazorModule)
    )]
public class ModuleTopic6BlazorServerModule : AbpModule
{

}
