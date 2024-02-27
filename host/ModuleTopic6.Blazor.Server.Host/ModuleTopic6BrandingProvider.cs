using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ModuleTopic6.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class ModuleTopic6BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ModuleTopic6";
}
