using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using QuestionsAnswers.Authorization.Roles;
using QuestionsAnswers.Configuration;
using QuestionsAnswers.Localization;
using QuestionsAnswers.MultiTenancy;
using QuestionsAnswers.Users;

namespace QuestionsAnswers
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class QuestionsAnswersCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            QuestionsAnswersLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = QuestionsAnswersConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();


            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = QuestionsAnswersConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = QuestionsAnswersConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QuestionsAnswersCoreModule).GetAssembly());
        }

       
    }
}