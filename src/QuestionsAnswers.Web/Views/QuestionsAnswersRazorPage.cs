using Abp.AspNetCore.Mvc.Views;

namespace QuestionsAnswers.Web.Views
{
    public abstract class QuestionsAnswersRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected QuestionsAnswersRazorPage()
        {
            LocalizationSourceName = QuestionsAnswersConsts.LocalizationSourceName;
        }
    }
}
