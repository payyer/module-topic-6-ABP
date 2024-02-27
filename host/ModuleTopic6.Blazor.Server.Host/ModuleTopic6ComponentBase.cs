using ModuleTopic6.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ModuleTopic6.Blazor.Server.Host;

public abstract class ModuleTopic6ComponentBase : AbpComponentBase
{
    protected ModuleTopic6ComponentBase()
    {
        LocalizationResource = typeof(ModuleTopic6Resource);
    }
}
