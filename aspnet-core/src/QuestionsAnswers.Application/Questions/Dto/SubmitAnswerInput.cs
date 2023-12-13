using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace ModuleZeroSampleProject.Questions.Dto
{
    public class SubmitAnswerInput 
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}