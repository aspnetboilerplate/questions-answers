using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QuestionsAnswers.Configuration;
using QuestionsAnswers.EntityFrameworkCore;
using QuestionsAnswers.Migrator.DependencyInjection;

namespace QuestionsAnswers.Migrator
{
    [DependsOn(typeof(QuestionsAnswersEntityFrameworkModule))]
    public class QuestionsAnswersMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QuestionsAnswersMigratorModule(QuestionsAnswersEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(QuestionsAnswersMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                QuestionsAnswersConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
