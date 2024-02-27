using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleTopic6;

[DependsOn(
    typeof(ModuleTopic6ApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ModuleTopic6HttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ModuleTopic6ApplicationContractsModule).Assembly,
            ModuleTopic6RemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleTopic6HttpApiClientModule>();
        });

    }
}
