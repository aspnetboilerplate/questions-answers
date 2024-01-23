using Abp.Domain.Entities.Auditing;
using QuestionsAnswers.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsAnswers.Questions
{
    public class Question : CreationAuditedEntity<int, User>
    {
        public virtual string Title { get; set; }

        public virtual string Text { get; set; }

        public virtual int VoteCount { get; set; }

        public virtual int AnswerCount { get; set; }

        public virtual int ViewCount { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {

        }

        public Question(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
