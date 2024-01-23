using Abp.AspNetCore.Mvc.Controllers;

namespace QuestionsAnswers.Web.Controllers
{
    public abstract class QuestionsAnswersControllerBase: AbpController
    {
        protected QuestionsAnswersControllerBase()
        {
            LocalizationSourceName = QuestionsAnswersConsts.LocalizationSourceName;
        }
    }
}