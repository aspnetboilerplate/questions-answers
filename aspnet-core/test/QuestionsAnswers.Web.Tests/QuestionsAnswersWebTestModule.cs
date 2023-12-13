using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.EntityFrameworkCore;
using QuestionsAnswers.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace QuestionsAnswers.Web.Tests
{
    [DependsOn(
        typeof(QuestionsAnswersWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class QuestionsAnswersWebTestModule : AbpModule
    {
        public QuestionsAnswersWebTestModule(QuestionsAnswersEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(QuestionsAnswersWebMvcModule).Assembly);
        }
    }
}