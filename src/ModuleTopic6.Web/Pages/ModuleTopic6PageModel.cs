using ModuleTopic6.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ModuleTopic6.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ModuleTopic6PageModel : AbpPageModel
{
    protected ModuleTopic6PageModel()
    {
        LocalizationResourceType = typeof(ModuleTopic6Resource);
        ObjectMapperContext = typeof(ModuleTopic6WebModule);
    }
}
