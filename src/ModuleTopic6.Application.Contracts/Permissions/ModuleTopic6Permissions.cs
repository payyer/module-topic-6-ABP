using Volo.Abp.Reflection;

namespace ModuleTopic6.Permissions;

public class ModuleTopic6Permissions
{
    public const string GroupName = "ModuleTopic6";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ModuleTopic6Permissions));
    }
}
