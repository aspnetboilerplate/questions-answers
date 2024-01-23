using Abp.Application.Services.Dto;

namespace QuestionsAnswers.Questions.Dto
{
    public class GetQuestionInput : EntityDto
    {
        public bool IncrementViewCount { get; set; }
    }
}
