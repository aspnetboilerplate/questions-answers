using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionsAnswers.Questions;
using QuestionsAnswers.Questions.Dto;
using QuestionsAnswers.Web.Models.Question;

namespace QuestionsAnswers.Web.Controllers
{
    [AbpMvcAuthorize]
    public class QuestionController : QuestionsAnswersControllerBase 
    {
        private readonly IQuestionAppService _questionAppService;

        public QuestionController(IQuestionAppService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        public IActionResult Index(GetQuestionsInput input)
        {
            var questions = _questionAppService.GetQuestions(input);

            var model = new QuestionListViewModel
            {
                Questions = questions,
            };
            return View(model);
        }

        public  IActionResult EditModal(int questionId)
        {
            var output =  _questionAppService.GetQuestion(new GetQuestionInput
            {
                Id = questionId,
                IncrementViewCount = true
            });
         
            var model = ObjectMapper.Map<QuestionDetailModalViewModel>(output);

            return PartialView("_DetailModal", model);
        }
    }
}
