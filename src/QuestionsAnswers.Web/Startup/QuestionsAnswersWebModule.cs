using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.Configuration;
using QuestionsAnswers.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace QuestionsAnswers.Web.Startup
{
    [DependsOn(
        typeof(QuestionsAnswersApplicationModule), 
        typeof(QuestionsAnswersEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class QuestionsAnswersWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QuestionsAnswersWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(QuestionsAnswersConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<QuestionsAnswersNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(QuestionsAnswersApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(QuestionsAnswersWebModule).Assembly);
        }
    }
}
