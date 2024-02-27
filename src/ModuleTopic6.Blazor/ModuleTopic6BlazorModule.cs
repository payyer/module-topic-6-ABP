using Microsoft.Extensions.DependencyInjection;
using ModuleTopic6.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace ModuleTopic6.Blazor;

[DependsOn(
    typeof(ModuleTopic6ApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class ModuleTopic6BlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ModuleTopic6BlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<ModuleTopic6BlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ModuleTopic6MenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(ModuleTopic6BlazorModule).Assembly);
        });
    }
}
