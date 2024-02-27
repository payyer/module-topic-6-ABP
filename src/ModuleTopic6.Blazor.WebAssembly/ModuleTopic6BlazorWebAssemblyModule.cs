using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace ModuleTopic6.Blazor.WebAssembly;

[DependsOn(
    typeof(ModuleTopic6BlazorModule),
    typeof(ModuleTopic6HttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class ModuleTopic6BlazorWebAssemblyModule : AbpModule
{

}
