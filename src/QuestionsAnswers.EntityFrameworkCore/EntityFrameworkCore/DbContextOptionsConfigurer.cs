using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace QuestionsAnswers.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
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
