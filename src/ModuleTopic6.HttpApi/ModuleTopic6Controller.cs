using ModuleTopic6.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ModuleTopic6;

public abstract class ModuleTopic6Controller : AbpControllerBase
{
    protected ModuleTopic6Controller()
    {
        LocalizationResource = typeof(ModuleTopic6Resource);
    }
}
