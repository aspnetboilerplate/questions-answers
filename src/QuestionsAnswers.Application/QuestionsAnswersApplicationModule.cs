using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.Authorization;
using QuestionsAnswers.Configuration;

namespace QuestionsAnswers
{
    [DependsOn(
        typeof(QuestionsAnswersCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QuestionsAnswersApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QuestionsAnswersAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QuestionsAnswersApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

            Configuration.Settings.Providers.Add<MySettingProvider>();
        }
    }
}