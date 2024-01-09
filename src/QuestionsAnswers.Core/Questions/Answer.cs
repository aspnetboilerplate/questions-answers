using Abp.Domain.Entities.Auditing;
using QuestionsAnswers.Users;

namespace QuestionsAnswers.Questions
{
    public class Answer : CreationAuditedEntity<int, User>
    {
        public virtual string Text { get; set; }

        public virtual Question Question { get; set; }

        public virtual int QuestionId { get; set; }

        public virtual bool IsAccepted { get; set; }

        public Answer()
        {

        }

        public Answer(string text)
        {
            Text = text;
        }
    }
}
