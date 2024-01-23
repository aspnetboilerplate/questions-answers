using Abp.Application.Services.Dto;
using QuestionsAnswers.Questions.Dto;
using System.Collections.Generic;

namespace QuestionsAnswers.Web.Models.Question
{
    public class QuestionListViewModel
    {
        public PagedResultDto<QuestionDto> Questions { get; set; }
    }
}
