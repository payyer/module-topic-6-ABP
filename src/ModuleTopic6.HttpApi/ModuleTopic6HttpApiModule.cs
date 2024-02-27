using Localization.Resources.AbpUi;
using ModuleTopic6.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleTopic6;

[DependsOn(
    typeof(ModuleTopic6ApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ModuleTopic6HttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ModuleTopic6HttpApiModule).Assembly);
        });
    }
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ModuleTopic6Resource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
