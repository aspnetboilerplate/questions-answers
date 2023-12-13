using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using QuestionsAnswers.Authorization.Roles;
using QuestionsAnswers.Authorization.Users;
using QuestionsAnswers.MultiTenancy;
using ModuleZeroSampleProject.Questions;

namespace QuestionsAnswers.EntityFrameworkCore
{
    public class QuestionsAnswersDbContext : AbpZeroDbContext<Tenant, Role, User, QuestionsAnswersDbContext>
    {
        /* Define a DbSet for each entity of the application */


        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<Vote> Votes { get; set; }

        public QuestionsAnswersDbContext(DbContextOptions<QuestionsAnswersDbContext> options)
            : base(options)
        {
        }
    }
}
