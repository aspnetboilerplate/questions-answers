using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QuestionsAnswers.EntityFrameworkCore
{
    public static class QuestionsAnswersDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QuestionsAnswersDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QuestionsAnswersDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
