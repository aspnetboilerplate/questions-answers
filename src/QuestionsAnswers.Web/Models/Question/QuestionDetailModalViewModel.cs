using Abp.AutoMapper;
using QuestionsAnswers.Questions.Dto;

namespace QuestionsAnswers.Web.Models.Question
{
    [AutoMapFrom(typeof(GetQuestionOutput))]
    public class QuestionDetailModalViewModel
    {
        public QuestionWithAnswersDto Question { get; set; }
    }
}
