using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionsAnswers.Authorization.Roles;
using QuestionsAnswers.MultiTenancy;
using QuestionsAnswers.Questions;
using QuestionsAnswers.Users;

namespace QuestionsAnswers.EntityFrameworkCore
{
    public class QuestionsAnswersDbContext : AbpZeroDbContext<Tenant, Role, User, QuestionsAnswersDbContext>
    {
        public QuestionsAnswersDbContext(DbContextOptions<QuestionsAnswersDbContext> options) : base(options)
        {
        }

        //Add DbSet properties for your entities...
        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<Vote> Votes { get; set; }


    }
}
