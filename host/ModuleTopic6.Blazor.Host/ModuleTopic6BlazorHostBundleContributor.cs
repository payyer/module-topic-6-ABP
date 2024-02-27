using Volo.Abp.Bundling;

namespace ModuleTopic6.Blazor.Host;

public class ModuleTopic6BlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
