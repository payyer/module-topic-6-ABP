using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace ModuleTopic6.Web.Menus;

public class ModuleTopic6MenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(ModuleTopic6Menus.Prefix, displayName: "ModuleTopic6", "~/ModuleTopic6", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
