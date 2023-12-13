using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}