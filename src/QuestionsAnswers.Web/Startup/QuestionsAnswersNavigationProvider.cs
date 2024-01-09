using Abp.Application.Navigation;
using Abp.Localization;

namespace QuestionsAnswers.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class QuestionsAnswersNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Questions,
                        L("Questions"),
                        url: "Question",
                        icon: "fa fa-question"
                        )

                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, QuestionsAnswersConsts.LocalizationSourceName);
        }
    }
}
