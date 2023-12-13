using System.Threading.Tasks;
using QuestionsAnswers.Configuration.Dto;

namespace QuestionsAnswers.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
