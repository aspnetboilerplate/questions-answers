using Abp.Application.Services.Dto;

namespace ModuleZeroSampleProject.Questions.Dto
{
    public class GetQuestionOutput 
    {
        public QuestionWithAnswersDto Question { get; set; }
    }
}