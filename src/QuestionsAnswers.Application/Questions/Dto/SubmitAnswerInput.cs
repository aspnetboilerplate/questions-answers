using System;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers.Questions.Dto
{
    public class SubmitAnswerInput
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
