using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using QuestionsAnswers.Configuration.Dto;

namespace QuestionsAnswers.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QuestionsAnswersAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
