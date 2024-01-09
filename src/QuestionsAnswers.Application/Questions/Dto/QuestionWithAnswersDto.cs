using Abp.AutoMapper;
using System.Collections.Generic;

namespace QuestionsAnswers.Questions.Dto
{
    [AutoMapFrom(typeof(Question))]
    public class QuestionWithAnswersDto : QuestionDto
    {
        public List<AnswerDto> Answers { get; set; }
    }
}
