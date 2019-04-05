using Abp.Application.Navigation;
using Abp.Localization;

namespace ModuleZeroSampleProject.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class ModuleZeroSampleProjectNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Questions",
                        L("Questions"),
                        url: "#/questions",
                        icon: "fa fa-question"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#/users",
                        icon: "fa fa-users"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ModuleZeroSampleProjectConsts.LocalizationSourceName);
        }
    }
}
