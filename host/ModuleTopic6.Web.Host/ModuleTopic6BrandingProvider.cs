using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ModuleTopic6;

[Dependency(ReplaceServices = true)]
public class ModuleTopic6BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ModuleTopic6";
}
