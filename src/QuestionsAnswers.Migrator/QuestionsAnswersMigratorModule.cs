using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using QuestionsAnswers.Configuration;
using QuestionsAnswers.DependencyInjection;
using QuestionsAnswers.EntityFrameworkCore;

namespace QuestionsAnswers.Migrator
{
    [DependsOn(typeof(QuestionsAnswersEntityFrameworkCoreModule))]
    public class QuestionsAnswersMigratorModule:AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QuestionsAnswersMigratorModule(QuestionsAnswersEntityFrameworkCoreModule abpProjectNameEntityFrameworkModule)
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
