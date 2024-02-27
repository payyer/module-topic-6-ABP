using ModuleTopic6.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ModuleTopic6.Pages;

public abstract class ModuleTopic6PageModel : AbpPageModel
{
    protected ModuleTopic6PageModel()
    {
        LocalizationResourceType = typeof(ModuleTopic6Resource);
    }
}
