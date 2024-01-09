using System;
using System.Threading.Tasks;
using Abp.TestBase;
using QuestionsAnswers.EntityFrameworkCore;
using QuestionsAnswers.Tests.TestDatas;

namespace QuestionsAnswers.Tests
{
    public class QuestionsAnswersTestBase : AbpIntegratedTestBase<QuestionsAnswersTestModule>
    {
        public QuestionsAnswersTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<QuestionsAnswersDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<QuestionsAnswersDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<QuestionsAnswersDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<QuestionsAnswersDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<QuestionsAnswersDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<QuestionsAnswersDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<QuestionsAnswersDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<QuestionsAnswersDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
