using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.Configuration;

namespace QuestionsAnswers.Web.Host.Startup
{
    [DependsOn(
       typeof(QuestionsAnswersWebCoreModule))]
    public class QuestionsAnswersWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QuestionsAnswersWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersWebHostModule).GetAssembly());
        }
    }
}
