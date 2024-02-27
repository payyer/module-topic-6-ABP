using ModuleTopic6.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ModuleTopic6.Permissions;

public class ModuleTopic6PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ModuleTopic6Permissions.GroupName, L("Permission:ModuleTopic6"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ModuleTopic6Resource>(name);
    }
}
