using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.Web.Startup;
namespace QuestionsAnswers.Web.Tests
{
    [DependsOn(
        typeof(QuestionsAnswersWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class QuestionsAnswersWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersWebTestModule).GetAssembly());
        }
    }
}