using QuestionsAnswers.Configuration;
using QuestionsAnswers.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QuestionsAnswers.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class QuestionsAnswersDbContextFactory : IDesignTimeDbContextFactory<QuestionsAnswersDbContext>
    {
        public QuestionsAnswersDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QuestionsAnswersDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(QuestionsAnswersConsts.ConnectionStringName)
            );

            return new QuestionsAnswersDbContext(builder.Options);
        }
    }
}