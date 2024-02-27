using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ModuleTopic6;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ModuleTopic6InstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ModuleTopic6InstallerModule>();
        });
    }
}
