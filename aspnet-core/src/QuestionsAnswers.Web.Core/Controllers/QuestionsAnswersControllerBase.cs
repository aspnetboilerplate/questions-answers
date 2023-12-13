using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QuestionsAnswers.Controllers
{
    public abstract class QuestionsAnswersControllerBase: AbpController
    {
        protected QuestionsAnswersControllerBase()
        {
            LocalizationSourceName = QuestionsAnswersConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
