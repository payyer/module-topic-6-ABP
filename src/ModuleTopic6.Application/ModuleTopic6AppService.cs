using ModuleTopic6.Localization;
using Volo.Abp.Application.Services;

namespace ModuleTopic6;

public abstract class ModuleTopic6AppService : ApplicationService
{
    protected ModuleTopic6AppService()
    {
        LocalizationResource = typeof(ModuleTopic6Resource);
        ObjectMapperContext = typeof(ModuleTopic6ApplicationModule);
    }
}
