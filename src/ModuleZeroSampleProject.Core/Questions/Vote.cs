using Abp.Domain.Entities.Auditing;
using ModuleZeroSampleProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleZeroSampleProject.Questions
{
    public class Vote : CreationAuditedEntity<long>
    {
        public long UserId { get; set; }
       
        public int QuestionId { get; set; }
  
        public bool UpVote { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
    }
}
