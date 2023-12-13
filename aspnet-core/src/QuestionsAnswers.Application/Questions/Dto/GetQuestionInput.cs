using Abp.Application.Services.Dto;

namespace ModuleZeroSampleProject.Questions.Dto
{
    public class GetQuestionInput :EntityDto
    {
        public bool IncrementViewCount { get; set; }
    }
}