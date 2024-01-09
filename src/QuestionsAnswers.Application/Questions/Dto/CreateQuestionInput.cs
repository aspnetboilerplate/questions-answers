using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers.Questions.Dto
{
    public class CreateQuestionInput
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
